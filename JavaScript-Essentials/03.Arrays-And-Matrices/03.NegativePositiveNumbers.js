function sortNumbers(array) {
    let result = [];

    for (var element of array) {
        if (Number(element) < 0) {
            result.unshift(element);
        } else {
            result.push(element);
        }
    }

    for (var element of result) {
        console.log(element);        
    }
}

sortNumbers([7, -2, 8, 9]);