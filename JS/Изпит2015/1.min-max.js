function solve(args){
    var k=+args[1]; 
    var numbers=args[2].split(' ').map(Number);

    var result='';

    for (var i = 0; i <= numbers.length-k; i+=1) {
        var min=1000000001;
        var max=-1000000001;

        for (var j = i; j < i+k; j+=1) {
            if (numbers[j]>max) {
                max=+numbers[j];
            }
            if (numbers[j]<min) {
                min=+numbers[j];
            }
        }
        var subsum=(min+max).toString();
        result+=','+subsum;
    }
    console.log(result.slice(1));
}
solve(['4',
       '2',
       '1 3 1 8' ]);

solve(['5',
       '3',
       '7 7 8 9 10']);