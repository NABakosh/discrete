const truthTable = [0, 1, 1, 0]

const sdnfTerms = []
const sknfTerms = []

let index = 0
for (let a = 0; a <= 1; a++) {
	for (let b = 0; b <= 1; b++) {
		const value = truthTable[index]

		if (value === 1) {
			const termA = a === 1 ? 'A' : '!A'
			const termB = b === 1 ? 'B' : '!B'
			sdnfTerms.push(`(${termA} && ${termB})`)
		} else {
			const termA = a === 0 ? 'A' : '!A'
			const termB = b === 0 ? 'B' : '!B'
			sknfTerms.push(`(${termA} || ${termB})`)
		}

		index++
	}
}

const sdnf = sdnfTerms.length > 0 ? sdnfTerms.join(' || ') : 'отсутствует'
const sknf = sknfTerms.length > 0 ? sknfTerms.join(' && ') : 'отсутствует'

console.log('СДНФ: ' + sdnf)
console.log('СКНФ: ' + sknf)
console.log('Минимизированная форма: ' + minimizeTwoVar(truthTable))

function minimizeTwoVar(table) {
	if (table.every(v => v === 0)) return '0'
	if (table.every(v => v === 1)) return '1'

	const terms = []

	if (table[2] === 1 && table[3] === 1) terms.push('A')
	if (table[1] === 1 && table[3] === 1) terms.push('B')
	if (table[0] === 1 && table[1] === 1) terms.push('!A')
	if (table[0] === 1 && table[2] === 1) terms.push('!B')

	if (terms.length > 0) {
		return terms.join(' || ')
	}

	const minterms = []
	if (table[0] === 1) minterms.push('(!A && !B)')
	if (table[1] === 1) minterms.push('(!A && B)')
	if (table[2] === 1) minterms.push('(A && !B)')
	if (table[3] === 1) minterms.push('(A && B)')

	return minterms.join(' || ')
}
