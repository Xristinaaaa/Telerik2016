function solve(args){
    var rowsCols=args[0].split(' '),
        rows=+rowsCols[0],
        cols=+rowsCols[1];
    var startPos=args[1].split(' '),
        row=+startPos[0],
        col=+startPos[1];
    var field=args.slice(2);
    var sum=0,
        count=0,
        dir,
        key,
        visited={};
    
    var directions={
        l: {
            row:0,
            col:-1
        },
        r: {
            row:0,
            col:+1
        },
        u: {
            row:-1,
            col:0
        },
        d: {
            row:+1,
            col:0
        }
    };

    while(true){
        if(row>=rows|| col>=cols || row<0 || col<0){
            return 'out ' + sum;
        }
        if(visited[row*cols+col]){
            return 'lost ' + count;
        }

        visited[row*cols+col]=true;
        count+=1;
        sum += row * cols + col + 1;

        dir=field[row][col];
        row+=directions[dir].row;
        col+=directions[dir].col;
    }
}
var tests=(
    [   "3 4",
        "1 3",
        "lrrd",
        "dlll",
        "rddd" 
    ],
    [
        "5 8",
        "0 0",
        "rrrrrrrd",
        "rludulrd",
        "durlddud",
        "urrrldud",
        "ulllllll"       
    ],
    [
        "5 8",
        "0 0",
        "rrrrrrrd",
        "rludulrd",
        "lurlddud",
        "urrrldud",
        "ulllllll"
    ]);

tests.forEach(function(test) {
    return solve(test);
});