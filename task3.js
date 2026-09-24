const X = [1, 2, 3]
const M = [
	[0, 0, 1],
	[1, 0, 1],
	[0, 1, 0],
]
const n = M.length

const isReflexive = matrix => {
	for (let i = 0; i < n; i++) {
		if (matrix[i][i] != 1) {
			return false
		}
	}
	return true
}

const isSymmetry = matrix => {
	for (let i = 0; i < n; i++) {
		for (let j = 0; j < n; j++) {
			if (matrix[i][j] !== matrix[j][i]) return false
		}
	}
	return true
}

const isAntiSymmetry = matrix => {
	for (let i = 0; i < n; i++) {
		for (let j = 0; j < n; j++) {
			if (i !== j && matrix[i][j] === 1 && matrix[j][i] === 1) {
				return false
			}
		}
	}
	return true
}
const isTransitive = matrix => {
	for (let i = 0; i < n; i++) {
		for (let j = 0; j < n; j++) {
			for (let k = 0; k < n; k++) {
				if (matrix[i][j] === 1 && matrix[j][k] === 1) {
					if (matrix[i][k] !== 1) return false
				}
			}
		}
	}
	return true
}
console.log('Рефлексивность:', isReflexive(M))
console.log('Симметричность:', isSymmetry(M))
console.log('Антисимметричность:', isAntiSymmetry(M))
console.log('Транзитивность:', isTransitive(M))
