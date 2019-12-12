function calculate(firstNumber, secondNumber, operator) {
    function add(x, y) { return x + y };
    function subtract(x, y) { return x - y };
    function multiply(x, y) { return x * y };
    function divide(x, y) { return x / y };
    function getDivisionLeftover(x, y) { return x % y };
    function pow(x, y) { return x ** y };
    
    let result;

    switch (operator) {
        case '+': result = add(firstNumber, secondNumber); break;
        case '-': result = subtract(firstNumber, secondNumber); break;
        case '*': result = multiply(firstNumber, secondNumber); break;
        case '/': result = divide(firstNumber, secondNumber); break;
        case '%': result = getDivisionLeftover(firstNumber, secondNumber); break;
        case '**': result = pow(firstNumber, secondNumber); break;
    }

    console.log(result);
}

calculate(18, -1, '*');