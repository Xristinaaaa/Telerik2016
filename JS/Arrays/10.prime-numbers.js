function prime(args){
    var number= args[0],
        isPrime;

    for (var i = number; i > 0; i-=1) {
        isPrime=true;
        for (var j = 2; j <= Math.sqrt(i); j++) {
            if (i%j===0) {
                isPrime=false;
                break;
            }
        }
        if (isPrime) {
            console.log(i);
            break;
        }
    }
}
prime(['126']);