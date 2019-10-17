function calculateArea(argument){
    let result;
    if (typeof(argument) == 'number') {
        result = Math.PI * argument * argument;
        result = result.toFixed(2);
    }
    else {
        result = `We can not calculate the circle area, because we receive a ${typeof(argument)}.`;
    }

    return result;
}

