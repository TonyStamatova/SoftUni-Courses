function  add(stringArray){
    let firstNum = Number(stringArray[0]);
    let lastNum = Number(stringArray[stringArray.length - 1]);
    console.log(firstNum + lastNum);
}

add(['5', '10']);