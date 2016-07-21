function solve(args){
    let heights=args[0].split(' ').map(Number);
    let sumOfPockets=0;

    for (var i = 0; i < heights.length; i+=1) {
        if (isGreaterThan(i, heights)) {
            heights[i]=51;
        }
    }

    for (var j = 1; j < heights.length-1; j+=1) {
        if (+heights[j-1]===51 && +heights[j+1]===51) {
            sumOfPockets+=(+heights[j]);
        }
    }
    console.log(sumOfPockets);

    function isGreaterThan(index, arr) {
        return arr[index-1]<arr[index] &&
                arr[index+1]<arr[index];
    }
}
solve(["53 20 1 30 2 40 3 10 1"]);
solve(["53 20 1 30 30 2 40 3 10 1"]);