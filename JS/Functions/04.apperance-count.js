function count(args){
    var length=+args[0],
        numbers = args[1].split(' '),
        x=+args[2],
        count=0;
        
    for (var i = 0; i < length; i+=1) {
        if (+numbers[i]===x) {
            count+=1;
        }
    }
    console.log(count);
}
count(['8','28 6 21 6 -7856 73 73 -56','73']);