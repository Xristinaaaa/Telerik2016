function solve(args) {
    let normal='<orgcase>',
        closeNormal='</orgcase>',
        uppercase='<upcase>',
        closeUpper='</upcase>',
        lowercase='<lowcase>',
        closeLower='</lowcase>';

    for (var i = 0; i < args.length; i+=1) {
        if (args[i]===normal) {
            args.slice(i,1);
            args.slice(indexOf(closeNormal),1);
        }   
        else if(args[i]===uppercase){        
            for (var k = i+1; k < indexOf(closeUpper); k+=1) {
                args[k].toUpperCase();
            }        
            args.slice(i,1);
            args.slice(indexOf(closeUpper),1);
        }
        else if(args[i]===lowercase){
            for (var j = i+1; j < indexOf(closeUpper); j+=1) {
                args[j].toLowerCase();
            }       
            args.slice(i,1);
            args.slice(indexOf(closeLower),1);
        }
    }
    console.log(args.slice());
}
solve(
 [ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]
);