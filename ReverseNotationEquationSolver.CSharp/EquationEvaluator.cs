using System;
using System.Collections.Generic;

namespace ReverseNotationEquationSolver.CSharp
{
    //didn't want to create partial class for Program to split code into modules
    //so separate class created
    public class EquationEvaluator
    {
        private string[] SplitEquationToArray(in string equation)
        {
            return equation.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        private EvaluationResult EvaluateEquation(in string[] equationItems, 
            in Stack<decimal> operandStack,
            in IReadOnlyDictionary<string, Func<decimal, decimal, decimal>> supportedOperations)
        {
            if (equationItems.Length == 0)
            {
                return new EvaluationResult("Equation is empty");
            }

            foreach (var equationItem in equationItems)
            {
                if (decimal.TryParse(equationItem, out var operand))
                {
                    operandStack.Push(operand);
                }
                else if(supportedOperations.TryGetValue(equationItem, out var operation))
                {
                    if (operandStack.Count < 2)
                    {
                        return new EvaluationResult("Not enough operands to evaluate equation");
                    }
                    operandStack.Push(operation.Invoke(operandStack.Pop(), operandStack.Pop()));
                }
                else
                {
                    return new EvaluationResult($"Lexeme '{equationItem}' is not supported");
                }               
            }

            if (operandStack.Count > 1)
            {
                return new EvaluationResult("Too many operands to evaluate equation");
            }

            return new EvaluationResult(operandStack.Pop());
        }

        public EvaluationResult Evaluate(in string equation)
        {
            return EvaluateEquation(SplitEquationToArray(equation),
                new Stack<decimal>(),
                new Dictionary<string, Func<decimal, decimal, decimal>>
                {
                    { "+", (b, a) => a + b},
                    { "-", (b, a) => a - b},
                    { "*", (b, a) => a * b},
                    { "/", (b, a) => a / b},
                });
        }
    }
}
