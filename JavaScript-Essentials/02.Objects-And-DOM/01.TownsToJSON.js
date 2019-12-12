function solve(input){
    let towns = []; 

    for (let i = 1; i < input.length; i++) {
        let townInfo = input[i].split(/ *\|{1} */g);
        let town = {
            "Town": townInfo[1], 
            "Latitude": Number(townInfo[2]), 
            "Longitude": Number(townInfo[3])
        };
        towns[i - 1] = town;
    }

    console.log(JSON.stringify(towns));
}

solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
)
