function calculate(array){
    let sum = 0;
    let sumOfInverse = 0;
    let concatenated = "";

    for (let value of array) {
        let number = Number(value);
        sum += number;
        sumOfInverse += (1 / number);
        concatenated += value;
    }

    console.log(sum);
    console.log(sumOfInverse);
    console.log(concatenated);
}

calculate([1, 2, 3]);