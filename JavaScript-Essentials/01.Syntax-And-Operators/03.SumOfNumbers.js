function sum(n, m){
    let sum = 0;
    let firstNumber = Number(n);
    let lastNumber = Number(m);

    for (let i = firstNumber; i <= lastNumber; i++) {
        sum += i;
    }

    console.log(sum);
}

sum('-8', '20');