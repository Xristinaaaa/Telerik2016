function solve() {
    return function (selector, tabs) {
        var root = document.querySelector(selector);
        var tabsIn = tabs || [];
        var fragment = document.createDocumentFragment();

        //first ul
        var tabsNav = document.createElement('ul');
        tabsNav.className = '.tabs-nav';
        var tabsNavLi = document.createElement('li');
        var tabsNavLiLink = document.createElement('a');

        for (var i = 0, len = tabsIn.length; i < len; i += 1) {
            var li = tabsNavLi.cloneNode(true);
            var link = tabsNavLiLink.cloneNode(true);
            link.className = '.tab-link ' + i;
            link.innerHTML = tabsIn[i].title;

            link.addEventListener('click', function (ev) {
                var childToDisplay = ev.target;
                var elementToChange = tabsContent[i];

                if (elementToChange.classList.contains('.visible')) {
                    elementToChange.className -= '.visible';
                } else {
                    elementToChange.className += ' .visible';
                }
            }, false);

            li.appendChild(link);
            tabsNav.appendChild(li);
        }

        //second ul
        var tabsContent = document.createElement('ul');
        tabsContent.className = '.tabs-content';
        var tabsContentLi = document.createElement('li');
        var tabsContentLiContent = document.createElement('p');
        var tabsContentLiButton = document.createElement('button');

        for (var j = 0, len2 = tabsIn.length; j < len2; j += 1) {
            var contentLi = tabsContentLi.cloneNode(true);
            contentLi.className = '.tab-content';

            if (j === 0) {
                contentLi.className += ' .visible';
            }

            var content = tabsContentLiContent.cloneNode(true);
            content.innerHTML = tabsIn[j].content;
            var button = tabsContentLiButton.cloneNode(true);
            button.className = '.btn-edit';
            button.innerHTML = 'Edit';

            button.addEventListener('click', function (ev) {
                var clickedButton = ev.target;
                clickedButton.innerHTML = '';
                clickedButton.innerHTML = 'Save';

                var textArea = document.createElement('textarea');
                textArea.className = '.edit-content';
                textArea.innerHTML = clickedButton.previousElementSibling.value;

                clickedButton.parentElement.appendChild(textArea);

            }, false);

            contentLi.appendChild(content);
            contentLi.appendChild(button);
            tabsContent.appendChild(contentLi);
        }
        fragment.appendChild(tabsNav);
        fragment.appendChild(tabsContent);
        root.appendChild(fragment);
    };
}

// submit the above!

if (typeof module !== 'undefined') {
    module.exports = solve;
}