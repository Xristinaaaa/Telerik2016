function mmsa(args){
  var length=args.length;

  var min,
      max,
      sum,
      average;

  min=+args[0];
  max=+args[0];
  sum=+args[0];
  average=0;

  for (var i = 1; i < length; i++) {
    if (+args[i]<min) {
      min=+args[i];
    }
    if (+args[i]>max) {
      max=+args[i];
    }
    sum+= +args[i];
  }

  average=sum/length;

  console.log("min="+min.toFixed(2));
  console.log("max="+max.toFixed(2));
  console.log("sum="+sum.toFixed(2));
  console.log("avg="+average.toFixed(2));
}
