function sort(args) {
    var arrayLength = +args[0],
        array = args[1].split(' ').map(Number);

    var sortedArray = array.sort(function (a, b) {
        return a - b });

    return sortedArray.join(' ');
}
sort(['10 36 10 1 34 28 38 31 27 30 20']);