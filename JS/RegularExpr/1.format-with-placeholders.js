function solve(args){
    var str1=JSON.parse(args[0]);
    var result=args[1];

    for(var i in str1){
        var regex=new RegExp('#\{'+i+'\}', 'g');
        result=result.replace(regex, str1[i]);
    }
    console.log(result);
}
solve(['{ "name": "John" }', 
          "Hello, there! Are you #{name}?"]);