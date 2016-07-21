function firstLarger(args){
    var length=+args[0],
        numbers=args[1].split(' '),
        index;

    for (var i = 1; i < length-1; i+=1) {
        if (+numbers[i]>+numbers[i+1] && +numbers[i]>+numbers[i-1]) {
            index=i;
            break;
        }
    }
    console.log(index===-1?-1:index);
}
firstLarger(['6' ,'-26 -25 -28 31 2 27']);