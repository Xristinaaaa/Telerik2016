//Write a program that compares two char arrays lexicographically (letter by letter).

function solve(args) {
    var arrays=args[0].split('\n'),
        arr1=String(arrays[0]),
        arr2=String(arrays[1]);
    
    if (arr1>arr2) {
        console.log('>');
    }
    else if(arr1<arr2) {
        console.log('<');
    }
    else {
        console.log('=');
    }
    /*
        arr1=arrays[0],
        arr2=arrays[1];

    result=arr1.localeCompare(arr2);

    if (result===1) {
        console.log(">");
    }
    else if(result===-1) {
        console.log("<");
    }
    else {
        console.log("=");
    }
    */
}

solve(['food\food']);