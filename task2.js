const X = [1, 2, 3, 4]
const Y = [2, 4, 6, 3]

function f(x) {
	return x * 2
}
function g(x) {
	return x + 10
}

const main = (X, Y, f) => {
	const values = X.map(x => f(x))
	const uniqueValues = new Set(values)

	const isInjective = uniqueValues.size === values.length
	const isSurjective = Y.every(y => uniqueValues.has(y))
	const isBijection = isInjective && isSurjective
	console.log(
		'Injection:',
		isInjective,
		' Bijection:',
		isBijection,
		' Surjection',
		isSurjective,
	)
}
main(X, Y, f)
function compose(f, g) {
	return function (x) {
		return g(f(x))
	}
}
const composeResult = compose(f, g)
console.log('Compose:', composeResult(3))
