function getTownInfo(arrayOfTowns) {
    let towns = {};

    for (let i = 0; i < arrayOfTowns.length; i++) {
        let current = arrayOfTowns[i].split(" <-> ");
        let townName = current[0];
        let population = Number(current[1]);

        if (!towns[townName]) {
            towns[townName] = 0;
        }

        towns[townName] += population;
    }

    for (var town in towns) {
        console.log(`${town} : ${towns[town]}`);
    }   
}

getTownInfo(["Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Las Vegas <-> 1000000"
    ])