function remove(args){
    var toRemove=args[0];
    Array.prototype.remove=function(rem){
        var result=[];

        for(var i in this){
            if (this[i]!==rem) {
                result.push(this[i]);
            }
        }
        return result;
    };

    console.log(args.remove(toRemove).join('\n'));
}
remove([ '1', '2', '3', '2', '1', '2', '3', '2' ]);