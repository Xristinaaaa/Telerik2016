/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        var root = document.querySelector(selector);
        var fragment = document.createDocumentFragment();

        var inputType = root.getElementsByClassName('tb-pattern')[0];
        var button = root.getElementsByClassName('btn-add')[0];

        var list = root.getElementsByClassName('suggestions-list');
        var suggestions = initialSuggestions || [];


        function checkIfDuplicate(currentSuggestion) {
            for (var i = 0, len = suggestions.length; i < len; i += 1) {
                if (currentSuggestion !== undefined) {
                    if (currentSuggestion.toLowerCase() === suggestions[i].getElementsByTagName('a')[0].innerHTML.toLowerCase()) {
                        return true;
                    }
                }
            }
        }

        function createSuggestion(element) {
            var li = document.createElement('li');
            li.className = 'suggestion';
            var itemName = document.createElement('a');
            itemName.className = 'suggestion-link';
            itemName.innerHTML = element;

            li.appendChild(itemName);
            list.appendChild(li);

            return li;
        }

        inputType.addEventListener('input', function () {
            if (inputType.value === '') {
                return;
            }

            var search = inputType.value.toLowerCase();

            for (var i = 0, len = list.length; i < len; i += 1) {
                var text = suggestions[i].getElementsByTagName('a')[0].innerHTML.toLowerCase();

                if (search.indexOf(text) < 0) {
                    suggestions[i].style.display = 'none';
                } else {
                    suggestions[i].style.display = '';
                }
            }

        }, false);

        list.addEventListener('click', function (ev) {
            var target = ev.target;

            if (target.className === 'suggestion-link') {
                inputType.value = target.innerHTML;
            }
            if (target.className === 'suggestion') {
                inputType.value = target.firstChild.innerHTML;
            }

        }, false);

        button.addEventListener('click', function (ev) {
            if (inputType.value.length > 0) {
                if (!checkIfDuplicate(inputType.value)) {
                    createSuggestion(inputType.value);
                }

                inputType.value = '';

                for (var i = 0, len = suggestions.length; i < len; i += 1) {
                    suggestions[i].style.display = 'none';
                }
            }
        }, false);

        fragment.appendChild(list);
        root.appendChild(fragment);
    };
}

module.exports = solve;