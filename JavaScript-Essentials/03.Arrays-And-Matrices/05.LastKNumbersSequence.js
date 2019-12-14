function printSequence(n, k){
    let result = [];
    result.push(1);

    for (let i = 1; i < n; i++) {
        let elements = result.slice(Math.max(0, i - k), i);
        let sum = elements.reduce((x,y) => x + y);
        result.push(sum);
    }

    console.log(result.join(" "));
}

printSequence(6, 3);