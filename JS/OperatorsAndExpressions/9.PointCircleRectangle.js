function solve(args){
  var x=+args[0];
  var y=+args[1];
  var inCirle=Math.pow(x-1,2)+Math.pow(y-1,2)<=Math.pow(1.5,2)
  var inRectangle=(x >= -1 && x <= 5) && (y >= -1 && y <= 1);
  if (inCirle) {
    if (inRectangle) {
      console.log("inside circle inside rectangle");
    }
    else {
      console.log("inside circle outside rectangle");
    }
  }
  else {
    if (inRectangle) {
      console.log("outside circle inside rectangle");
    }
    else {
      console.log("outside circle outside rectangle");
    }
  }
}
