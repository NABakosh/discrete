const AND = (x, y) => +(x && y)
const OR = (x, y) => +(x || y)
const NOT = x => +!x
const IMP = (x, y) => +(!x || y)
const EQV = (x, y) => +(x === y)
const XOR = (x, y) => +(x !== y)
const x = [0, 1, 0, 1, 0, 1]
const y = [0, 1, 1, 1, 0, 0]
const f = (x, y) => NOT(AND(x, y))
const g = (x, y) => OR(NOT(x), NOT(y))

console.log('f(1, 0) =', f(1, 0))

function check(f, g) {
	let equal = true
	console.log('x y | f g')
	for (let x = 0; x <= 1; x++) {
		for (let y = 0; y <= 1; y++) {
			console.log(x, y, '|', f(x, y), g(x, y))
			if (f(x, y) !== g(x, y)) equal = false
		}
	}
	return equal
}

console.log('Эквивалентны:', check(f, g))

console.log('x y | AND OR IMP EQV XOR NOT(x)')
for (let x = 0; x <= 1; x++) {
	for (let y = 0; y <= 1; y++) {
		console.log(
			x,
			y,
			'|',
			AND(x, y),
			OR(x, y),
			IMP(x, y),
			EQV(x, y),
			XOR(x, y),
			NOT(x),
		)
	}
}

const h = (x, y) => AND(x, y)
console.log('f и h эквивалентны:', check(f, h))
