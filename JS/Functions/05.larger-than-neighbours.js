function larger(args){
    var length=+args[0],
        numbers=args[1].split(' '),
        largerThanNeighbours=0;

    for (var i = 1; i < length-1; i+=1) {
        if (+numbers[i]>+numbers[i+1] && +numbers[i]>+numbers[i-1]) {
            largerThanNeighbours+=1;
        }
    }
    console.log(largerThanNeighbours);
}
larger(['6', '-26 -25 -28 31 2 27']);