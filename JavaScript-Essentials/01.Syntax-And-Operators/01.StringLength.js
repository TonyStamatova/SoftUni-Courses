function calculateLengths(firstString, secondString, thirdString){
    let sum = firstString.length + secondString.length + thirdString.length;
    console.log(sum);
    let average = sum / 3;
    console.log(Math.floor(average));
}

calculateLengths('pasta', '5', '22.3')