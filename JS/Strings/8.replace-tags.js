function solve(args) {
    var regExTag = new RegExp('<a href="(.*?)">(.*?)</a>', "g");
   
    var newText = args[0].replace(regExTag, function (none, href, content) {
        
            return '[' + content + '](' + href + ')';      
    });
    console.log(newText);
}
solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);