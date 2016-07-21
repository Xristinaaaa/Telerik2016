//Write a program that allocates array of N integers, initializes each element by its index multiplied by 5 
//and the prints the obtained array on the console.

function solve(number){
    var arr=[];
    arr.length=number;
    for (var index = 0; index < arr.length; index+=1) {
        arr[index]=index*5;
        console.log(arr[index]);
    }
}

solve(['5']);