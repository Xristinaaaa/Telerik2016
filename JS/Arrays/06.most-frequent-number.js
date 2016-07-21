function frequence(args){
    var numbers = args[0].split('\n').slice(1).map(Number),
        temp=1,
        mostFrequent,
        times=1;

    numbers.sort();
    for (var i = 0; i < numbers.length-1; i+=1) {
        if (+numbers[i]===+numbers[i+1]) {
            temp+=1;
            if(+temp>=+times) {
                times=+temp;
                mostFrequent=+numbers[i];
            }
        } 
        else {
            if (+temp>=+times) {
                times=+temp;
                mostFrequent=+numbers[i];
                temp=1;
            }    
            else {
                temp=1;
            }
        }
    }
    console.log(mostFrequent + " (" + times + " times)");    
}
frequence(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);