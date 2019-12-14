function findBiggest(matrix) {
    let biggest;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] > biggest || !biggest) {
                biggest = matrix[row][col];
            }
        }
    }

    console.log(biggest);
}

findBiggest([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]
);