function solve() {
  return function (selector) {
    var $element = $(selector).css({ display: 'none' }).hide();
    var children=$(selector).children;
    var $list = $('<div />').addClass('.dropdown-list');
    $list.append($element);

    var $current = $('<div />').addClass('.current').attr('data-value', '').text('Option 1');
    $list.append($current);

    var $optionsContainer = $('<div />').addClass('.options-container')
      .css({ 'position': 'absolute', 'display': 'none'});
    $list.append($optionsContainer);

    var $divToAppend;
    for (var i = 1; i < children.length; i += 1) {
      $divToAppend = $('<div />').addClass('.dropdown-item')  
          .attr('data-value', $(children[i]).val())
          .attr('data-index', i - 1)
          .text($(children[i]).text())
          .appendTo($optionsContainer);
    }

    $current.click(function(){
      $optionsContainer.css({'display': 'inline-block'});
    });
  };
}

module.exports = solve;