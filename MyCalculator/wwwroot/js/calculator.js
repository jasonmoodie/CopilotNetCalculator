document.addEventListener('DOMContentLoaded', function() {
    const display = document.getElementById('display');
    let current = '0';
    let operator = null;
    let operand = null;
    let resetNext = false;

    function updateDisplay() {
        display.textContent = current;
    }

    function inputDigit(digit) {
        if (resetNext) {
            current = digit === '.' ? '0.' : digit;
            resetNext = false;
        } else if (digit === '.') {
            if (!current.includes('.')) current += '.';
        } else {
            current = current === '0' ? digit : current + digit;
        }
        updateDisplay();
    }

    function clearAll() {
        current = '0';
        operator = null;
        operand = null;
        resetNext = false;
        updateDisplay();
    }

    function clearEntry() {
        current = '0';
        updateDisplay();
    }

    function setOperator(op) {
        if (operator && !resetNext) {
            calculate();
        }
        operand = parseFloat(current);
        operator = op;
        resetNext = true;
    }

    function calculate() {
        if (operator && operand !== null) {
            let result;
            const curr = parseFloat(current);
            switch (operator) {
                case 'add': result = operand + curr; break;
                case 'subtract': result = operand - curr; break;
                case 'multiply': result = operand * curr; break;
                // TODO: Add operator
                case 'divide': result = curr !== 0 ? operand / curr : 'Error'; break;
            }
            current = result.toString();
            operator = null;
            operand = null;
            resetNext = true;
            updateDisplay();
        }
    }

    document.querySelectorAll('.calc-btn').forEach(btn => {
        if (btn.classList.contains('empty')) return;
        btn.addEventListener('click', function() {
            const value = btn.getAttribute('data-value');
            const action = btn.getAttribute('data-action');
            if (value !== null) {
                inputDigit(value);
            } else if (action) {
                switch (action) {
                    case 'clear': clearAll(); break;
                    case 'clear-entry': clearEntry(); break;
                    case 'add': setOperator('add'); break;
                    case 'subtract': setOperator('subtract'); break;
                    case 'multiply': setOperator('multiply'); break;
                    case 'divide': setOperator('divide'); break;
                    // TODO: Add operator
                    case 'equals': calculate(); break;
                }
            }
        });
    });
    updateDisplay();
});