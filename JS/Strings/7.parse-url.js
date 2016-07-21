function solve(args){
    let text=String(args);
    let indexOfcol=text.indexOf(':');
    let indexOfSlash=text.indexOf('/');
    let protocol=text.substring(0, indexOfSlash-1);
    let temp=text.slice(indexOfSlash+2);
    let server=temp.substring(0, temp.indexOf('/'));
    let resource=temp.slice(temp.indexOf('/'));
    

    console.log('protocol: '+protocol);
    console.log('server: '+server);
    console.log('resource: '+resource);
}
solve([ 'http://telerikacademy.com/Courses/Courses/Details/239' ]);