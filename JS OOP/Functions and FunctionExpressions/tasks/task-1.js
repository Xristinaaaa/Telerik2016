/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/
'use strict';
function sum(items) {
    let itemsSum = 0,
		len = items.length;

	if (!len) {
		return null;
	}

	if (items === 'undefined') {
		throw new Error();
	}

	for (var i = 0; i < len; i += 1) {
		if (isNaN(+items[i])) {
			throw new Error();
		}
	}

    for (let item of items) {
        itemsSum += (+item);
    }

    return itemsSum;
}

module.exports = sum;