function findOddNumber(array){
    let result = [];

    for (const index in array) {
        if (index % 2 != 0) {
            let newElement = array[index] * 2;
            result.unshift(newElement);
        }
    }

    console.log(result.join(" "));
}

findOddNumber([3, 0, 10, 4, 7, 3]);