function solve(args) {
/*   var clean=(String(args)).replace(/(<([^>]+)>)/ig, "").split(',').map(function trim(element) {
       return element.trim();
    });
    var result='';
    for (var i = 0; i < clean.length; i+=1) {
        if (clean[i].length>1) {
            result+=clean[i];
        }
    }
    console.log(result);
*/

  var result = '';

  for (var i in args) {
    var parse = args[i].trim();
    
    for (var index = 0; index < parse.length; index += 1) {
      var chr = parse[index];

      if (chr === '<') {
        isTag = true;
      }
      else if (chr === '>') {
        isTag = false;
      }
      else if (!isTag) {
        result += chr;
      }
    }
  }
  console.log(result);
}
solve(
[
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);