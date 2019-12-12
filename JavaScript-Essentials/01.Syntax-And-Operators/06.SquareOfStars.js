function printRectangle(size = 5){
    for (let i = 0; i < size; i++) {
        printRow(size);
    }
    
    function printRow(length){
        console.log('* '.repeat(length));
    }
}



printRectangle();