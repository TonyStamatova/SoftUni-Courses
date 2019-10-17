function drawSquare(size = 5) {
    let star = '* ';
    for(let i = 0; i < size; i++)
    {
        console.log(star.repeat(size));
    }
}