function sum(first, second){
    let result = 0;
    let firstNum = Number(first);
    let secondNum = Number(second);

    for (let i = firstNum; i <= secondNum; i++) {
        result+=i;
    }

    return result;
}

sum('1', '5' );