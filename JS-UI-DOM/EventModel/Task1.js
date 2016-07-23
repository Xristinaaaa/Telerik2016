function solve() {
    return function (element) {
        var result,
            buttons,
            content;

        if (typeof element === 'string') {
            resullt = document.getElementById(element);
        }
        else if (element instanceof HTMLElement) {
            result = element;
        }
        else {
            throw new Error();
        }

        buttons = result.childNodes.getElementsByClassName('button');
        for (var i = 0, len = buttons.length; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
            buttons[i].addEventListener('click', handleClick, false);
        }

        function handleClick(ev) {
            var clickedButton = ev.target,
                next = clickedButton.nextElementSibling;

            if (next.className === 'content') {
                content = next;

                while (next) {
                    if (next.className === 'button') {

                        if (content.style.display === 'none') {
                            content.style.display = '';
                            clickedButton.innerHTML = 'hide';
                        } else {
                            content.style.display = 'none';
                            clickedButton.innerHTML = 'show';
                        }
                        break;
                    }
                    next = next.nextElementSibling;
                }
            }
        }
    };
}
module.exports = solve();
