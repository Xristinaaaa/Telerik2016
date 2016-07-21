
function solve(lines){
  var valley=lines[0].split(',').map((Number));

function isOutside(valley, index){
    return valley[index]===undefined;
  }

function coinsForPattern(valley, pattern){
    var visited=[],
        coins=0,
        index=0,
        patternIndex=0;
    
    //continue while not visited and inside valley
    while(!visited[index] && !isOutside(valley, index)){
        coins+=valley[index];
        visited[index]=true;
        
        index+=pattern[patternIndex];

        patternIndex=(patternIndex+1)%pattern.length;
    }
    return coins;
}

var M=Number(lines[1]);
var results=[];
for (var i = 2; i < lines.length; i+=1) {
    var pattern =lines[i].split(',').map(Number);
    results.push(coinsForPattern(valley,pattern));
}

var maxCoins=Math.max.apply(null, results);
console.log(maxCoins);

// read input
    // read the valley, convert to numbers array
    //read the patterns, convert to numbers array
        //read a single pattern 
    //find max coins that can be collected following a pattern
    //for every pattern calculate the coins
        //find a way to calculate coins for a single pattern
            //start from 0
            //follow the pattern
            //collect coins on the way
            //if end of pattern start from the beginning of the pattern
            //if outside of valley or on visited index, stop following the pattern
    //find the max coins
    //return max coins
}
var test1=[
  '1, 3, -6, 7, 4 , 1, 12',
  '3',
  '1, 2, -3',
  '1, 3, -2',
  '1, -1',
];

solve(test1);