using System;
using System.Collections.Generic;
using System.Linq;

namespace FormulaCalculation
{
    public class CalculationService
    {
        private readonly char[] _operatorArr = new[] { '+', '-', '*', '/' };

        public double Calculate(string line)
        {
            string lineWithoutSpace = line.Replace(" ", "");
            int l = lineWithoutSpace.Length;

            var numberStack = new Stack<double>();
            var operatorStack = new Stack<char>();
            int i = 0;
            while (i < l)
            {
                var curCh = lineWithoutSpace[i];

                if (IsNumber(curCh))
                {
                    int j = i;
                    while (j < l && IsNumber(lineWithoutSpace[j]))
                    {
                        j++;
                    }
                    double thisNum = double.Parse(lineWithoutSpace.Substring(i, j - i));
                    numberStack.Push(thisNum);
                    i = j;
                }
                else if (curCh == '(')
                {
                    operatorStack.Push(curCh);
                    i++;
                }
                else if (curCh == ')')
                {
                    while(operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    {
                        double newValue = DoMath(operatorStack.Pop(), numberStack.Pop(), numberStack.Pop());
                        numberStack.Push(newValue);
                    }
                    i++;
                }
                else if (_operatorArr.Contains(curCh))
                {
                    while (operatorStack.Count > 0 && IsLowerPriority(curCh, operatorStack.Peek()))
                    {
                        double newValue = DoMath(operatorStack.Pop(), numberStack.Pop(), numberStack.Pop());
                        numberStack.Push(newValue);
                    }
                    operatorStack.Push(curCh);

                    i++;
                }
            }

            while (operatorStack.Count > 0)
            {
                double newValue = DoMath(operatorStack.Pop(), numberStack.Pop(), numberStack.Pop());
                numberStack.Push(newValue);
            }

            return numberStack.Pop();
        } 

        private bool IsNumber(char c)
        {
            return c >= '0' && c <= '9';
        }

        private static bool IsLowerPriority(char operator1, char operator2)
        {
            if (operator2 == '(' || operator2 == ')')
                return false;
            else if ((operator1 == '+' || operator1 == '-') && (operator2 == '*' || operator2 == '/'))
                return false;
            else
                return true;
        }

        private static double DoMath(char opreator, double b, double a)
        {
            switch (opreator)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }

            throw new Exception($"{opreator} is not a operator");
        }
    }
}
