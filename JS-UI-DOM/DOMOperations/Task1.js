'use strict';
function solve() {
    return function result(element, contents) {
        var el;
        if (element === string) {
            el=document.getElementById(element);
        }
        else if (element instanceof HTMLElement) {
            el=element;
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
        el.appendChild(fragment);
    };
}
solve(['']);