function findEvenElements(input){
    let newArray = [];

    for (let i = 0; i < input.length; i++) {
        if (i % 2 == 0) {
            newArray.push(input[i]);
        }
    }

    console.log(newArray.join(" "));
}

findEvenElements(['20', '30', '40']);