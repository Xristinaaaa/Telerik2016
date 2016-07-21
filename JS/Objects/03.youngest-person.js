function solve(args) {
    var length=+args.length;
    
    var min=1000;
    var index;
    for (var i = 2; i < length; i+=3) {
        if (+args[i]<min) {
            min=+args[i];
            index=i;
        }
    }
    var firstName=args[index-2];
    var lastName=args[index-1];

    return firstName+ " "+ lastName;
}
solve([ 'Gosho', 'Petrov', '32',
        'Bay', 'Ivan', '81',
        'John', 'Doe', '42']);