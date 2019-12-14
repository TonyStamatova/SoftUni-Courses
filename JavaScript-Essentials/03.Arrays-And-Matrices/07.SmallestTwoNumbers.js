function findSmallestNumbers(array) {
    let smallest = Number.MAX_VALUE;
    let secondSmallest = Number.MAX_VALUE;

    for (const element of array) {
        if (element <= smallest) {
            secondSmallest = smallest;
            smallest = element;
        } else if (element < secondSmallest) {
            secondSmallest = element;
        }
    }

    if (array.length < 1) {
        return;
    } else if (array.length < 2) {
        secondSmallest = "";
    }

    console.log(`${smallest} ${secondSmallest}`);
}

findSmallestNumbers([3, 0, 10, 4, 7, 3]);