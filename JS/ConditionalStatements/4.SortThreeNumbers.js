function sort(args){
  var num1=+args[0];
  var num2=+args[1];
  var num3=+args[2];

  if (num1>num2 && num1>num2)
  {
      if (num2 > num3)
      {
          console.log(num1 + " " + num2 + " "+ num3);
      }
      else if(num3 > num2)
      {
          console.log(num1 + " " + num3 + " " + num2);
      }
      else if(num2 == num3)
      {
          console.log(num1 + " " + num2 + " " + num3);
      }
  }
  else if (num2>num1 && num2>num3)
  {
      if (num1 > num3)
      {
          console.log(num2 + " " + num1 + " " + num3);
      }
      else if(num3 > num1)
      {
          console.log(num2 + " " + num3 + " " + num1);
      }
      else if (num1 == num3)
      {
          console.log(num2 + " " + num1 + " " + num3);
      }
  }
  else if (num3>num1 && num3>num2)
  {
      if (num2 > num1)
      {
          console.log(num3 + " " + num2 + " " + num1);
      }
      else if(num1 > num2)
      {
          console.log(num3 + " " + num1 + " " + num2);
      }
      else if (num1 == num2)
      {
          console.log(num3 + " " + num1 + " " + num2);
      }
  }
  else if (num1 === num2 === num3)
  {
      console.log(num1 + " " + num2 + " " + num3);
  }
}
