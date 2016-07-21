function solve(args) {
    let word= args[0].toLowerCase();
    let text=args[1].toLowerCase();

    let matches=0;
    var index=text.indexOf(word);

    while (index>=0) {
        matches+=1;
        index=text.indexOf(word, index+1);
    }
    console.log(matches);
}
solve(
[   'in',
    'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
]);