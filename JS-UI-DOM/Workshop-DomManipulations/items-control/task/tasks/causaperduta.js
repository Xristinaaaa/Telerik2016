function solve() {

    return function (selector, isCaseSensitive) {
        isCaseSensitive = !!isCaseSensitive;
        if (!selector || !(selector instanceof HTMLElement)) {
            throw new Error();
        }

        var root = document.querySelector(selector);
        root.className = 'items-control';

        var fragment = document.createDocumentFragment();

        //Adding
        var addingDiv = document.createElement('div');
        addingDiv.className = 'add-controls';

        var label1 = document.createElement('label');
        label1.innerHTML = 'Enter text: ';
        var inputAdd = document.createElement('input');
        label1.appendChild(inputAdd);

        var button = document.createElement('a');
        button.className = 'button';
        button.innerHTML = 'Add';
        button.style.display = 'inline-block';
        button.addEventListener('click', onButtonClick, false);

        addingDiv.appendChild(label1);
        addingDiv.appendChild(button);
        //

        //Searching
        var searchingDiv = document.createElement('div');
        searchingDiv.className = 'search-controls';

        var label2 = document.createElement('label');
        label2.innerHTML = 'Search: ';

        var inputSearch = document.createElement('input');
        inputSearch.addEventListener('input', onSearchType, false);

        label2.appendChild(inputSearch);

        searchingDiv.appendChild(label2);
        //

        //Result
        var resultDiv = document.createElement('div');
        resultDiv.className = 'result-controls';

        var itemsList = document.createElement('ul');
        itemsList.className = 'items-list';

        var listItem = document.createElement('li');
        listItem.className = 'list-item';

        var buttonToDelete = document.createElement('a');
        buttonToDelete.className('button button-delete');
        buttonToDelete.innerHTML = 'X';

        var text = document.createElement('strong');
        listItem.appendChild(buttonToDelete);
        listItem.appendChild(text);

        itemsList.addEventListener('click', itemsListClick, false);

        resultDiv.appendChild(itemsList);
        
        var allListItems = document.getElementsByClassName('list-item');
        //


        //Events
        function onButtonClick(ev) {
            var value = inputAdd.value;
            inputAdd.value = "";
            text.innerHTML = value;
            itemsList.appendChild(listItem.cloneNode(true));
        }

        function onSearchType(ev) {
            var text,
                pattern = inputSearch.value;

            if (!isCaseSensitive) {
                pattern = pattern.toLowerCase();
            }

            for (var i = 0, len = allListItems.length; i < len; i += 1) {
                text = allListItems[i].getElementsByTagName("strong")[0].innerHTML;
                if (!isCaseSensitive) {
                    text = text.toLowerCase();
                }

                if (text.indexOf(pattern) < 0) {
                    allListItems[i].style.display = "none";
                } else {
                    allListItems[i].style.display = "";
                }
            }
        }

        function itemsListClick(ev) {
            var button= ev.target,
                parrent;

            if(button.className.indexOf('button-delete')<0){
                return;
            }
            parrent=button;

            while(parent && parent.className.indexOf('list-item')<0){
                parrent=parrent.parrentNode;
            }

            if(!parent){
                return;
            }
            
            itemsList.removeChild(parent);
        }
        //

        fragment.appendChild(addingDiv);
        fragment.appendChild(searchingDiv);
        fragment.appendChild(resultDiv);

        root.appendChild(fragment);
    };
}

module.exports = solve;