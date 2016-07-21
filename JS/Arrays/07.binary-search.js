function search(args){
    var numbers= args[0].split('\n').map(Number);
    var x=+numbers[numbers.length-1],
        index=0,
        left=0,
        right=numbers.length-1,
        mid=0;

    numbers.shift();
    
    while (left<=right)
    {
         mid = ((left + right) / 2)|0;
        if (x == +numbers[mid])
        {
            index = mid;
            console.log(index);
            return;
        }
        else if (x > +numbers[mid])
        {
            left = mid + 1;
        }
        else if (x < +numbers[mid])
        {
            right = mid - 1;
        }
    }

    if (index===0)
    {
        console.log('-1');
    }
}

search(['10', '1', '2', '4', '8', '16', '31', '32', '64', '77', '99', '32']);

