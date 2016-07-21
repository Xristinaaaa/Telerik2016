function solve(args) {
    var s=+args[0],
        c1=+args[1],
        c2=+args[2],
        c3=+args[3];

    var max=Math.max(c1,c2,c3),
        min=Math.min(c1,c2,c3),
        medium,
        temp=0,
        sum=0;
    
    if (max>c1 && c1>min) {
        medium=c1;
    }
    else if(max>c2 && c2>min)
    {
        medium=c2;
    }
    else{
        medium=c3;
    }

    //highest price
    for (var i = 0; i <= s/max; i+=1) {
        //medium price
        for (var j = 0; j <= s/medium; j+=1) {
            //cheapest price
            for (var k = 0; k <= s/min; k+=1) {
                if (i*max+j*medium+k*min<=s) {
                    temp=i*max+j*medium+k*min;
                    if (temp>sum) {
                        sum=temp;
                    }
                }
            }
        }
    }
    console.log(sum);
}
var tests= [
    ['110',
     '13',
     '15',
     '17'],

    ['20',
    '11',
    '200',
    '300'
    ],

    ['110',
     '19',
     '29',
     '29'
    ]
]