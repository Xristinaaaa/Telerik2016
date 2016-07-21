function solve(args) {
  var number=+args[0];
  if (number%5 && number%7) {
    console.log("false "+number);
  }
  else {
    if (number%5) {
      console.log("false "+number);
    }
    else if (number%7) {
      console.log("false "+number);
    }
    else {
      console.log("true "+ number);
    }
  }
}
