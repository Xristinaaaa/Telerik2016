const Validator = (() => {
    function validateString(str) {
        if (typeof str !== 'string') {
            throw new Error("Input is not a string!");
        }
    }

    function validateLengthOfString(str, minLength, maxLength) {
        if (str.length <= minLength || str.length >= maxLength) {
            throw new Error("Invalid length of string!");
        }
    }

    function validateLatinLetters(str) {
        const invalidSymbols = /[^a-zA-Z ]/.test(str);

        if (invalidSymbols) {
            throw new Error("String should contain only latin letters!");
        }
    }

    function validateUrl(str) {
        const urlregex = ('^(https?:\/\/)?' + '((([a-z\d]([a-z\d-]*[a-z\d])*)\.)+[a-z]{2,}|' +
            '((\d{1,3}\.){3}\d{1,3}))' + '(\:\d+)?(\/[-a-z\d%_.~+]*)*' +
            '(\?[;&a-z\d%_.~+=-]*)?' + '(\#[-a-z\d_]*)?$', 'i').test(str);

        if (!urlregex) {
            throw new Error("Invalid url!");
        }
    }
    return {
        validateString,
        validateLengthOfString,
        validateLatinLetters,
        validateUrl
    };
});

export { Validator };