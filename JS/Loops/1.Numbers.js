function numbers(args){
  var num=+args[0];
  var result="";
  for (var i = 1; i <= num; i++) {
    result+=i+ " ";
  }
  console.log(result);
}
numbers(['5']);
