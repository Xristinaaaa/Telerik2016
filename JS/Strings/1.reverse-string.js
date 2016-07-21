function solve(args) {
    let str=String(args);
        result='';
    
    for (var i = str.length-1; i >= 0; i-=1) {
        result=result+str[i];
    }
    console.log(result);
  }
  solve([ 'sample' ]);