function calculate(input){
    let inputType = typeof(input);

    if (inputType == "number") {
        let radius = Number(input);
        let area = Math.PI * radius * radius;
        console.log(area.toFixed(2));
        return;
    }

    console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
}

calculate(true)