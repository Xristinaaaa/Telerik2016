function words(args){
  var number=args[0];
  var result = '';
  var onesLow = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
  var onesUp = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'];
  var tensLow = ['', 'ten', 'twenty', 'thirty', 'fourty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety',];
  var tensUp = ['', 'Ten', 'Twenty', 'Thirty', 'Forty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety',];
  var teensLow = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
  var teensUp = ['Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'];

  var hundreds = number / 100 | 0;
	var tens = (number / 10) % 10 | 0;
	var ones = number % 10;

  if (hundreds===0) {
    if (tens===0) {
      if (ones===0) {
        console.log("Zero");
      }
      else {
        console.log(onesUp[ones]);
      }
    }
    else {
      if (tens===1) {
        if (ones===0) {
          console.log("Ten");
        }
        else {
          console.log(teensUp[ones]);
        }
      }
      else{
        if (ones===0) {
          console.log(tensUp[tens]);
        }
        else {
          console.log(tensUp[tens]+" "+onesLow[ones]);
        }
      }
    }
  }
  else {
    if (tens===0) {
      if (ones===0) {
        console.log(onesUp[hundreds]+ " hundred");
      }
      else {
        console.log(onesUp[hundreds]+ " hundred and "+onesLow[ones]);
      }
    }
    else {
      if (tens===1) {
        if (ones===0) {
          console.log(onesUp[hundreds]+ " hundred and ten" );
        }
        else {
          console.log(onesUp[hundreds]+ " hundred and "+teensLow[ones]);
        }
      }
      else{
        if (ones===0) {
          console.log(onesUp[hundreds]+ " hundred and "+tensLow[tens]);
        }
        else {
          console.log(onesUp[hundreds]+ " hundred and "+tensLow[tens]+" "+ onesLow[ones]);
        }
      }
    }
  }
}
