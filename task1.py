from enum import Enum

class MESIState(Enum):
    MODIFIED = "M"
    EXCLUSIVE = "E"
    SHARED = "S"
    INVALID = "I"

class CacheLine:
    def __init__(self, address, value, state=MESIState.INVALID):
        self.address = address
        self.value = value
        self.state = state

    def __repr__(self):
        return f"[Val: {self.value} | MESI: {self.state.value}]"

class SystemBus:
    """Шина, связывающая ядра для синхронизации состояний MESI."""
    def __init__(self):
        self.caches = []

    def register_cache(self, cache):
        self.caches.append(cache)

    def notify_read(self, requesting_core_id, address):
        """Проверяет, есть ли адрес в других кэшах при чтении."""
        found_in_others = False
        for cache in self.caches:
            if cache.core_id != requesting_core_id:
                line = cache.lines.get(address)
                if line and line.state != MESIState.INVALID:
                    found_in_others = True
                    # Если было M, переводим в S (данные «расшарены»)
                    if line.state == MESIState.MODIFIED:
                        line.state = MESIState.SHARED
                    elif line.state == MESIState.EXCLUSIVE:
                        line.state = MESIState.SHARED
        return found_in_others

    def notify_write(self, requesting_core_id, address):
        """Инвалидирует этот адрес во всех остальных кэшах при записи."""
        for cache in self.caches:
            if cache.core_id != requesting_core_id:
                line = cache.lines.get(address)
                if line and line.state != MESIState.INVALID:
                    line.state = MESIState.INVALID

class Cache:
    def __init__(self, core_id, bus):
        self.core_id = core_id
        self.bus = bus
        self.lines = {}

    def read(self, address):
        line = self.lines.get(address)
        
        # Cache Hit
        if line and line.state != MESIState.INVALID:
            print(f"[Core {self.core_id}] Read HIT: {address} = {line.value} ({line.state.value})")
            return line.value

        # Cache Miss
        print(f"[Core {self.core_id}] Read MISS: {address}")
        # Оповещаем шину и читаем из «памяти» (фиктивное значение 0)
        other_has_it = self.bus.notify_read(self.core_id, address)
        new_state = MESIState.SHARED if other_has_it else MESIState.EXCLUSIVE
        
        self.lines[address] = CacheLine(address, value=0, state=new_state)
        return self.lines[address].value

    def write(self, address, value):
        line = self.lines.get(address)

        # Инвалидируем копии у остальных ядер через шину
        self.bus.notify_write(self.core_id, address)

        # Записываем значение себе в статусе Modified
        self.lines[address] = CacheLine(address, value, state=MESIState.MODIFIED)
        print(f"[Core {self.core_id}] Write: {address} = {value} (State -> M)")


# --- Пример работы ---
bus = SystemBus()
cache1 = Cache(core_id=1, bus=bus)
cache2 = Cache(core_id=2, bus=bus)
bus.register_cache(cache1)
bus.register_cache(cache2)

# 1. Ядро 1 читает адрес 0x0A -> статус E (так как больше ни у кого нет)
cache1.read("0x0A")

# 2. Ядро 2 читает тот же адрес -> переходит в S у обоих ядер
cache2.read("0x0A")

# 3. Ядро 1 перезаписывает адрес -> переходит в M у Ядра 1, и в I у Ядра 2
cache1.write("0x0A", value=42)

print("\nСостояние кэша 1:", cache1.lines)
print("Состояние кэша 2:", cache2.lines)