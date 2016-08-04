function solve() {
  return function () {
    $.fn.listview = function (data) {
      var element = $(this),
        templateId = element.attr('data-template'),
        templateSource = $('#' + templateId).html(),
        templateGenerate=handlebars.compile(templateSource);
      
      for(var i=0; i<data.length; i+=1){
        element.append(templateGenerate(data[i]));
      }
      return this;
    };
  };
}

module.exports = solve;