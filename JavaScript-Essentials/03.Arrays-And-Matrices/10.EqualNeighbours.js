function findEqualNeighbours(matrix) {
    let pairs = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            const element = matrix[row][col];

            if (matrix[row][col + 1]) {
                if (matrix[row][col + 1] === element) {
                    pairs++;
                }
            }

            if (matrix[row + 1] && matrix[row + 1][col]) {
                if (matrix[row + 1][col] === element) {
                    pairs++;
                }
            }
        }
    }

    console.log(pairs);    
}

findEqualNeighbours([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']
]);