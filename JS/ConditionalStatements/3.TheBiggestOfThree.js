function biggestOfThree(args){
  var num1=+args[0];
  var num2=+args[1];
  var num3=+args[2];

  if (num1>num2 && num1>num3)
   {
      console.log(num1);
   }
   else if (num2 > num1 && num2 > num3)
   {
      console.log(num2);
   }
   else
   {
       console.log(num3);
   }
}
