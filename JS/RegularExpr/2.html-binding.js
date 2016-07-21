function solve(args){
    var str1=JSON.parse(args[0]);
    var result=args[1];

    for(var i in str1){
        var regex=new RegExp('><', 'g');
        result=result.replace(regex, ('>'+str1[i]+'<'));
    }
    console.log(result);
}
solve(['{ "name": "Steven" }',
       '<div data-bind-content="name"></div>']);
solve([
    '{ "name": "Elena", "link": "http://telerikacademy.com" }',
    '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>']);