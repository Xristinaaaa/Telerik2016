function solve() {
    return function (fileContentsByName) {
        var $results = fileContentsByName;

        var $fileExplorer = $('#file-explorer');

        var $article = $fileExplorer.children('.file-preview');
        var $fileContentResult = $article.children('.file-content');

        var $section = $fileExplorer.children('.file-explorer');
        var $items = $section.children('.items');
        var $dirs = $items.children('.dir-item');
        var $delButtons=$fileExplorer.find('.del-btn');


        $items.on('click', '.item-name', function () {
            var clickedElement = $(this);
            var $text = clickedElement.text();
            $fileContentResult.text($results[$text]);
        });


        $dirs.on('click', function () {
            var $current = $(this);
            
            if ($current.hasClass('collapsed')) {
                $current.removeClass('collapsed');
            } else if(!$current.hasClass('collapsed')){
                $current.addClass('collapsed');
            }
        });

        $delButtons.on('click', function(){
            var $clickedElement=$(this);
            $clickedElement.parent().remove();
        });

        function createFile(file) {
            var li = $('<li />').addClass('file-item item');
            var itemName = $('<a />').addClass('item-name').html(file);
            var delBtn = $('<a />').addClass('del-btn');

            itemName.appendTo(li);
            delBtn.appendTo(li);

            return li;
        }
        
        var $buttonForAdding = $section.children('.add-wrapper');
        $buttonForAdding.on('click', '.add-btn', function () {
            var $current = $(this);
            $current.removeClass('visible');
            $current.next('input').addClass('visible');
        });

        var $inputTypeText = $buttonForAdding.find('input');
        $inputTypeText.on('keydown', function (ev) {
            if (ev.keyCode === 13) {
                var text = $inputTypeText.val();
                var file;

                if (text.indexOf('/') !== -1) {
                    var textParts = text.split('/');
                    var dir = textParts[0];
                    file = textParts[1];
                    var dirToPlaceIn;
                    var children = $dirs.children('.item-name');

                    for (var i = 0, len=children.length; i < len; i += 1) {
                        var currentName = $(children[i]).text();

                        if (currentName.toLowerCase() === dir.toLowerCase()) {
                            dirToPlaceIn = $(children[i]).parent();
                        }
                    }

                    if (dirToPlaceIn) {
                        dirToPlaceIn.find('.items').append(createFile(file));
                    }
                } else {
                    file = text;
                    items.append(createFile(file));
                }
            }
        });
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}