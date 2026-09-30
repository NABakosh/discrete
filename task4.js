const a = [1, 0, 1, 0]
const b = [0, 1, 1, 0]

function conuction() {
	return a.map((x, i) => {
		return x & b[i]
	})
}
function disuction() {
	return a.map((x, i) => {
		return x || b[i]
	})
}
function implication() {
	return a.map((x, i) => {
		if (b[i] >= x) {
			return 1
		}
		return 0
	})
}
function exivalent() {
	return a.map((x, i) => {
		return +(x === b[i])
	})
}
function xor() {
	return a.map((x, i) => {
		return +(x != b[i])
	})
}
function not() {
	const result = []
	result.push(
		a.map(x => {
			return +!x
		}),
	)
	result.push(
		b.map(x => {
			return +!x
		}),
	)
	return result
}
function taftology(req) {
	return !req.includes(0)
}
function contradaction(req) {
	return !req.includes(1)
}
function isContingency(req) {
	return req.includes(1) && req.includes(0)
}
console.log(not())
