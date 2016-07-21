function matrix(args){
  var number=+args[0];
  var result='';
  for (var i = 1; i <= number; i++) {
    for (var j = i; j <= number+(i-1); j++) {
      result+= j+ " ";
    }
    console.log(result);
    result='';
  }
}
