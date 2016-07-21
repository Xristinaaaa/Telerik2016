function hexToDecimal(args){
  var hexNumber=args[0];
  var length= args.length;
  var decNumber=0;

  for (var i = 0; i < length; i++) {
    switch (args[i]) {
      case '1':
        decNumber+=1*Math.pow(16,i);
        break;
      case '2':
        decNumber+=2*Math.pow(16,i);
        break;
      case '3':
        decNumber+=3*Math.pow(16,i);
        break;
      case '4':
        decNumber+=4*Math.pow(16,i);
        break;
      case '5':
        decNumber+=5*Math.pow(16,i);
        break;
      case '6':
        decNumber+=6*Math.pow(16,i);
        break;
      case '7':
        decNumber+=7*Math.pow(16,i);
        break;
      case '8':
        decNumber+=8*Math.pow(16,i);
        break;
      case '9':
        decNumber+=9*Math.pow(16,i);
        break;
      case 'A':
        decNumber+=10*Math.pow(16,i);
        break;
      case 'B':
        decNumber+=11*Math.pow(16,i);
        break;
      case 'C':
        decNumber+=12*Math.pow(16,i);
        break;
      case 'D':
        decNumber+=13*Math.pow(16,i);
        break;
      case 'E':
        decNumber+=14*Math.pow(16,i);
        break;
      case 'F':
        decNumber+=15*Math.pow(16,i);
        break;
      default:
        break;
    }
  }
  console.log(decNumber);
}
