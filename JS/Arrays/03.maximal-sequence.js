//Write a program that finds the length of the maximal sequence of equal elements in an array of N integers.
function max(args){
    var numbers = args[0].split('\n').slice(1).map(Number),
        temp=1,
        maxLength=1;

    for (var i = 0; i < numbers.length-1; i+=1) {
        if (+numbers[i]===+numbers[i+1]) {
            temp+=1;
        } 
        else {
            if (temp>maxLength) {
                maxLength=temp;
            }
            temp=1;
        }     
    }
    console.log(maxLength);
}

max(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']);