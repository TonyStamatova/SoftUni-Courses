function printNumbers(array) {
    let count = array.shift();
    let firstElements = array.slice(0, count);
    let lastElements = array.slice(array.length - count, array.length);
    console.log(firstElements.join(" "));
    console.log(lastElements.join(" "));    
}

printNumbers([2, 7, 8, 9]);