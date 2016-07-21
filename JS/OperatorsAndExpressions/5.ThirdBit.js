function solve(args){
  var number=+args[0];
  var mask=1<<3;
  var digit=number&mask;
  console.log(digit>>3);
}
