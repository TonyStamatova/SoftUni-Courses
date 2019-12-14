function findSmallestNumbers(matrix) {
    let mainDiagonalSum = 0;
    let secondaryDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (row == col) {
                mainDiagonalSum += matrix[row][col];
            }

            if (row + col == matrix.length - 1) {
                secondaryDiagonalSum += matrix[row][col];
            }
        }
    }

    console.log(`${mainDiagonalSum} ${secondaryDiagonalSum}`);
}

findSmallestNumbers([[20, 40], [10, 60]]);