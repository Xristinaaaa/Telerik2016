const Validator = {
    validateString(str) {
        if (typeof str !== 'string') {
            throw new Error("Input is not a string!");
        }
    },

    validateLengthOfString(str, minLength, maxLength) {
        if (str.length <= minLength || str.length >= maxLength) {
            throw new Error("Invalid length of string!");
        }
    },

    validateLatinLetters(str) {
        const invalidSymbols = /[^a-zA-Z ]/.test(str);

        if (invalidSymbols) {
            throw new Error("String should contain only latin letters!");
        }
    }
};