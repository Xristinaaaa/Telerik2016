function solve(args) {
    let rowsCols=args[0].split(' ').map(Number);
    let rows=+rowsCols[0],
        cols=+rowsCols[1];
    let startingPos=args[1].split(';');
    let startingW=startingPos[0].split(' ').map(Number),
        rowW=+startingW[0],
        colW=+startingW[1];
    let startingN=startingPos[1].split(' ').map(Number),
        rowN=+startingN[0],
        colN=+startingN[1];
    let startingL=startingPos[2].split(' ').map(Number),
        rowL=+startingL[0],
        colL=+startingL[1];

    var board=args.slice(2);
    var visited={}; 

    var directions={
        l: {
            row: 0,
            col:-1
        },
        r: {
            row: 0,
            col:+1
        },
        u: {
            row:-1,
            col: 0
        },
        d: {
            row:+1,
            col: 0
        }
    };

    for(var i=0; i<board.length; i+=1){
        if ((rowN==rowL && colN==colL)||(rowW==rowL && colW==colL)
             || (rowN==rowL-1 && colN==colL)||(rowW==rowL-1 && colW==colL)
             || (rowN==rowL+1 && colN==colL)||(rowW==rowL+1 && colW==colL)
             || (rowN==rowL && colN==colL-1)||(rowW==rowL && colW==colL-1)
             || (rowN==rowL && colN==colL+1)||(rowW==rowL && colW==colL+1)
             || (rowN==rowL-1 && colN==colL-1)||(rowW==rowL-1 && colW==colL-1)
             || (rowN==rowL+1 && colN==colL+1)||(rowW==rowL+1 && colW==colL+1)
             || (rowN==rowL-1 && colN==colL+1)||(rowW==rowL-1 && colW==colL+1)
             || (rowN==rowL+1 && colN==colL-1)||(rowW==rowL+1 && colW==colL-1)) {
            
            console.log("The trolls caught Lsjtujzbo at"+ rowL+ " "+ colL); 
            break;
        }
        if ((rowL>rows || colL>cols) || (visited[rowN*cols+colN]===true && visited[rowW*cols + colW]===true)) {
            console.log("Lsjtujzbo is saved!" + rowW+ " "+ colW +" "+ rowN+ " "+ colN);
            break; 
        }

        var dir;
        if(board[i].indexOf('N'!==-1)){
            if(! visited[rowN*cols+colN]){           
                dir=board[i].slice(board.length-1);
                rowN+=directions[dir].row;
                colN+=directions[dir].col;
            }
            else{
                if(visited[rowW*cols+colW]){
                    dir=board[i].slice(board.length-1);
                    rowN+=directions[dir].row;
                    colN+=directions[dir].col;
                }
                else{
                    continue;
                }
            }
        }
        else if(board[i].indexOf('W'!==-1)) {
            if(! visited[rowW*cols+colW])
            {
                dir=board[i].slice(board.length-1);
                rowW+=directions[dir].row;
                colW+=directions[dir].col;
            }
            else{
                if(visited[rowN*cols+colN]){
                    dir=board[i].slice(board.length-1);
                    rowW+=directions[dir].row;
                    colW+=directions[dir].col;
                }
                else {
                    continue;
                }
            }
        }
        else if(board[i].indexOf('L'!==-1)){
            dir=board[i].slice(board.length-1);
            rowL+=directions[dir].row;
            colL+=directions[dir].col;
        }
        else {
            visited[rowL*cols+colL]=true;
        }
    }
}
solve([ '5 5',
        '1 1;0 1;2 3',
        'mv Lsjtujzbo d',
        'lay trap',
        'mv Lsjtujzbo d',
        'mv Wboup r',
        'mv Wboup r',
        'mv Nbslbub d',
        'mv Nbslbub d',
        'mv Nbslbub d',
        'mv Nbslbub d',
        'mv Nbslbub d',
        'mv Wboup d',
        'mv Wboup d' ]);