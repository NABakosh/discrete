const table = [
	[0, 0, 0],
	[0, 1, 1],
	[1, 0, 1],
	[1, 1, 0],
]

function lit(name, value) {
	if (value === 1) return name
	return '¬' + name
}

function sdnf(table) {
	const terms = []
	for (const [x, y, f] of table) {
		if (f === 1) {
			terms.push('(' + lit('x', x) + ' ∧ ' + lit('y', y) + ')')
		}
	}
	return terms.join(' ∨ ')
}

function sknf(table) {
	const terms = []
	for (const [x, y, f] of table) {
		if (f === 0) {
			terms.push('(' + lit('x', 1 - x) + ' ∨ ' + lit('y', 1 - y) + ')')
		}
	}
	return terms.join(' ∧ ')
}

function minimize(table) {
	const ones = table.filter(r => r[2] === 1)
	const result = []

	for (let i = 0; i < ones.length; i++) {
		for (let j = i + 1; j < ones.length; j++) {
			if (ones[i][0] === ones[j][0]) result.push(lit('x', ones[i][0]))
			if (ones[i][1] === ones[j][1]) result.push(lit('y', ones[i][1]))
		}
	}

	if (result.length === 0) return sdnf(table)
	return [...new Set(result)].join(' ∨ ')
}

console.log('СДНФ:', sdnf(table))
console.log('СКНФ:', sknf(table))
console.log('Минимизация:', minimize(table))
