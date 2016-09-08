/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

'use strict';
function findPrimes(start, end) {
	start=+start;
	end=+end;
	var primeNums = [];

	if (isNaN(start) || isNaN(end)) {
		throw new Error();
	}

	for (var i = start; i <= end; i += 1) {
		if (isNaN(+(i))) {
			throw new Error();
		}

		if (isPrime(i)) {
			primeNums.push(i);
		}
	}

	function isPrime(number) {
		if (number < 2) {
			return false;
		}

		for (var j = 2; j <= Math.sqrt(number); j += 1) {
			if (number % j === 0) {
				return false;
			}
		}
		return true;
	}

	return primeNums;
}

module.exports = findPrimes;
