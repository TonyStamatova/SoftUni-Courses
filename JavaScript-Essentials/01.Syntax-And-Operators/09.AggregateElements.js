function aggregate(array){
    function sum(x) {return x.reduce((a,b) => a + b, 0)};
    function sumOfInverse(x) {return sum(x.map(x => 1 / x))};
    function concat(x) {return x.reduce((a,b) => a + b, "")};

    console.log(sum(array));
    console.log(sumOfInverse(array));
    console.log(concat(array));
}

aggregate([2, 4, 8, 16]);