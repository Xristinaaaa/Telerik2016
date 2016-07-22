'use strict';
function solve() {
    return function result(element, contents) {
        if (element === string) {
            element=document.getElementById(element);
        }
        else if (element instanceof HTMLElement) {
            element=element;
        }
        else {
            throw new Error();
        }

        if (!contents || (typeof contents.any != 'string' && typeof contents.any != 'number')) {
            throw new Error();
        }

        element.innerHTML = ''; 
        var fragment = document.createDocumentFragment();
        for (var i = 0, len = contents.length; i < len; i += 1) {
            fragment.innerHTML += contents[i];
        }
        element.appendChild(fragment);
    }
}
solve(['']);