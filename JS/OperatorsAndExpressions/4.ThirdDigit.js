function solve(args){
  var N=+args[0];
    if (N<100) {
      console.log("false 0");
    }
    else {
      N/=100;
      if (Math.floor(N%10)===7) {
        console.log("true");
      }
      else {
        console.log("false "+Math.floor(N%10));
      }
    }
}
