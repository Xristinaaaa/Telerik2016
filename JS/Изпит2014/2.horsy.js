function solve(args) {
    var rowsCols=args[0].split(' '),
        rows=rowsCols[0],
        cols=rowsCols[1];

    var points=0,
        moves=0,
        row=rows-1,
        col=cols-1,
        used={};

    var horseMoves=[[-2, 1], [-1, 2], [1, 2], [2, 1],
                    [2, -1], [1, -2], [-1, -2], [-2, -1]];

    function getPoints(row, col){
        return (1<<row)-col;
    }

    function getValue(args, row, col){
        return args[row+1][col];
    }
    while(true){
        if (row>=rows || col>=cols || row<0 || col<0) {
            console.log('Go go Horsy! Collected '+  weeds);
            break;
        }
        if (used[row + ' '+ col]) {
            console.log('Sadly the horse is doomed in '+ moves +' jumps');
            break;
        }
        moves+=1;
        points=points+getPoints(row, col);

        var move=horseMoves[getValue(args, row, col)-1];
        row+=move[0];
        col+=move[1];
        used[row + ';'+ col]=true;
    }
}
solve(['3 5',
       '54561',
       '43328',
       '52388']);