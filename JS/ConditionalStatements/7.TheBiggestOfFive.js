function biggestNum(args){
  var a=+args[0];
  var b=+args[1];
  var c=+args[2];
  var d=+args[3];
  var e=+args[4];

  if (a > b && a > c && a > d && a > e)
  {
      console.log(a);
  }
  else if (b > a && b > c && b > d && b > e)
  {
      console.log(b);
  }
  else if (c > a && c > b && c > d && c > e)
  {
      console.log(c);
  }
  else if (d > a && d > b && d > c && d > e)
  {
      console.log(d);
  }
  else
  {
      console.log(e);
  }
}