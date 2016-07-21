function coordinates(args){
    var firstLine=Math.sqrt(Math.pow(Math.abs(args[2] - args[0]),2)+Math.pow(Math.abs(args[3] - args[1]),2)).toFixed(2),
        secondLine=Math.sqrt(Math.pow(Math.abs(args[6] - args[4]),2)+Math.pow(Math.abs(args[7] - args[5]),2)).toFixed(2),
        thirdLine=Math.sqrt(Math.pow(Math.abs(args[10] - args[8]),2)+Math.pow(Math.abs(args[11] - args[9]),2)).toFixed(2);
    
    var formTriangle=false;
    if (firstLine+secondLine>thirdLine && firstLine+thirdLine>secondLine && secondLine+thirdLine>firstLine) {
        formTriangle=true;
    }

    console.log(firstLine);
    console.log(secondLine);
    console.log(thirdLine);

    if (formTriangle) {
        console.log("Triangle can be built");
    }
    else {
        console.log("Triangle can not be built");
    }
}
coordinates([  
  '5', '6', '7', '8',
  '1', '2', '3', '4',
  '9', '10', '11', '12']);