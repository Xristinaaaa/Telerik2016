function solve(args) {
    var number = +args[0];
    var prime = true;
    if (number < 2) {
        prime = false;
        console.log(prime);
    }
    else if (number < 4) {
        console.log(prime);
    }
    else {
        for (var i = 2; i < Math.sqrt(number); i+=1) {
            if (number % i === 0) {
                prime = false;
                break;
            }
        }
        console.log(prime);
    }
}
