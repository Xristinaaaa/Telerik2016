function quadraticEquation(args){
  var a=args[0];
  var b=args[1];
  var c=args[2];
  var descriminant=(b*b)-(4*a*c);

  var x1, x2;
  if (descriminant>0) {
    x1=(-b-Math.sqrt(descriminant))/(2*a);
    x2=(-b+Math.sqrt(descriminant))/(2*a);
    console.log("x1="+x1.toFixed(2)+"; "+"x2="+x2.toFixed(2));
  }
  else if (descriminant===0) {
    x1=x2=-b/(2*a);
    console.log("x1=x2="+x1.toFixed(2));
  }
  else {
    console.log("no real roots");
  }
}
