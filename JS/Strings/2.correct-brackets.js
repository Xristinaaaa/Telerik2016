function solve(args) {
    let str=String(args);
    let openBracket='(';
    let closeBracket=')';

    if (str[0]===closeBracket || str[str.length-1]===openBracket) {
        console.log('Incorrect');
    }
    else {
        let countOpen=0;
        let countClose=0;

        for (var i = 0; i < str.length; i+=1) {
            if (str[i]===openBracket) {
                countOpen+=1;
            }
            else if (str[i]===closeBracket) {
                countClose+=1;
            }
        }

        if (countOpen===countClose) {
            console.log('Correct');
        }
        else{
            console.log('Incorrect');
        }
    }
}
solve(['((a+b)/5-d)']);
solve([')(a+b))']);