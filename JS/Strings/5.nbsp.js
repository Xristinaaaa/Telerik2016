function solve(args) {
    let text=(String(args)).replace(/ /g, '&nbsp;');
    console.log(text);
}
solve(['hello world']);