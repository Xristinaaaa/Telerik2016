function solve(args){
    var numbers=args.slice(1).map(Number);
    var sum=numbers[0];

    for (var i = 0; i < numbers.length; i+=1) {
        var temp=0;
        for (var j = i; j < numbers.length; j+=1) {
            temp+=numbers[j];
            if (temp>sum) {
                sum=temp;
            }
        }
    }
    console.log(sum);
}
solve([ '8',
        '1',
        '6',
        '-9',
        '4',
        '4',
        '-2',
        '10',
        '-1' ]);