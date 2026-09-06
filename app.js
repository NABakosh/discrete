const join = (a, b) => {
	const con = a.concat(b)
	const result = new Set(con)
	return Array.from(result)
}
const intersect = (a, b) => {
	const result = []
	const len = Math.max(a.length, b.length)
	for (let i = 0; i < len; i++) {
		if (a.includes(b[i]) && !result.includes(b[i])) {
			result.push(b[i])
		}
	}
	return result
}
const difference = (a, b) => {
	const result = []
	for (let i = 0; i < a.length; i++) {
		if (!b.includes(a[i]) && !result.includes(a[i])) {
			result.push(a[i])
		}
	}
	return result
}
const symmetryDifference = (a, b) => {
	const diffA = a.filter(obj => !b.includes(obj))
	const diffB = b.filter(obj => !a.includes(obj))
	const con = diffA.concat(diffB)
	return Array.from(new Set(con))
}
const powerSet = a => {
	const result = []

	return result
}
const decarto = (a, b) => {
	const result = []
	for (let i = 0; i < a.length - 1; i++) {
		for (let j = 0; j < a.length + 1; j++) {
			result.push([a[i], b[j]])
		}
	}
	return result
}
const main = (a, b) => {
	// console.log(join(a, b))
	// console.log(intersect(a, b))
	// console.log(difference(a, b))
	// console.log(symmetryDifference(a, b))
	console.log(powerSet([1, 2, 3]))
	// console.log(decarto(a, b))
	console.log('main')
}
main([1, 4, 5, 7, 8], [2, 4, 1, 5, 7, 9])
