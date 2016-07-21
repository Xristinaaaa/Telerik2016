'use strict';
function solve() {
    function result(element, contents) {
        if (element === undefined || contents === undefined) {
            throw new Error();
        }
        if (!(element instanceof HTMLElement)) {
            throw new Error();
        }
        if (typeof contents.any != 'string' && typeof contents.any != 'number') {
            throw new Error();
        }

        element.innerHTML = '';
        var fragment = document.createDocumentFragment();
        for (var i = 0, len = contents.length; i < len; i += 1) {
            fragment.innerHTML += contents[i];
        }
        element.appendChild(fragment);
    }
    return result;
}
solve(['']);