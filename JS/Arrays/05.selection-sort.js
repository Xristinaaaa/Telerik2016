function sort(args){
    var numbers = args[0].split('\n').slice(1).map(Number);

    var temp;
    for (var i = 0; i < numbers.length-1; i+=1) {
        for (var j = i+1; j < numbers.length; j+=1) {
            if (+numbers[i]>+numbers[j]) {
                temp=+numbers[i];   
                numbers[i]=+numbers[j];
                numbers[j]=+temp;
            }
        }
    }
    console.log(numbers.join('\n'));
}

sort(['6', '3', '4', '1', '5', '2', '6']);