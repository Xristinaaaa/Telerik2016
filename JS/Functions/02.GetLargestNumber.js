function largestNumber(args) {
    var numbers= args[0].split(' ');

    console.log(GetMax(+numbers[0], GetMax(+numbers[1], +numbers[2])));
    function GetMax(a, b) {
        return a > b ? a : b;
    }
}
largestNumber(['8 3 6']);