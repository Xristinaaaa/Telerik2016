function solve(args) {
    var s=+args[0];
    var count=0,
        i,
        j,
        k;

    //10
    for (i = 0; i <= s/10; i+=1) {
        //4
        for (j = 0; j <= s/4; j+=1) {
           //3
           for (k = 0; k <= s/3; k+=1) {
               if (i*10+j*4+k*3===s) {
                   count+=1;
               }
           } 
        }
    } 
    console.log(count);
}
solve(['40']);