'use strict';
function solve() {
    return function result(element, contents) {
        if (typeof element === 'string') {
            if(!element) {
                throw new Error();
            }
            element = document.getElementById(element);
        }
        else if (!(element instanceof HTMLElement)) {
            throw new Error();
        }

        var fragment = document.createDocumentFragment(),
            div;

        for (var i = 0, len = contents.length; i < len; i += 1) {
            div = document.createElement('div');

            if (typeof (contents[i]) !== 'string' && typeof (contents[i]) !== 'number') {
                throw new Error();
            }

            div.innerHTML = contents[i];
            fragment.appendChild(div);
        }

        element.innerHTML = '';
        element.appendChild(fragment);
    };
}
module.exports=solve;