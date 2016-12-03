using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.ExpressionSolver
{
    public class NumericExpression
    {
        private static bool IsNumeric(string s, out double Number)
        {
            double Parsed = -1;
            Number = -1;
            if (double.TryParse(s, out Parsed))
            {
                Number = Parsed;
                return true;
            }
            return false;
        }

        private static bool hasPrecedence(string op1, string op2)
        {
            if (op2 == "(" || op2 == ")" || op2 == "^")
                return false;
            if ((op1 == "*" || op1 == "/") && (op2 == "+" || op2 == "-"))
                return false;
            else
                return true;
        }


        private static double PerformOperations(string op, double b, double a)
        {
            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0)
                        throw new DivideByZeroException();
                    return a / b;
                case "^":
                    return Math.Pow(a, b);
            }
            return 0;
        }

        public static  double Solve(string text)
        {
            if (text.StartsWith("-") || text.StartsWith("+"))
                text = "0" + text;

            char[] delimiterChars = { '+', '-', '*', '/', '^', '(', ')' };

            string[] words = text.Split(delimiterChars);
            List<string> Expression = words.ToList();
            Stack<double> Values = new Stack<double>();
            Stack<string> Operands = new Stack<string>();
            int count = 1;
            double Number;

            foreach (char c in text)
            {
                if (delimiterChars.Contains(c))
                {
                    Expression.Insert(count, c.ToString());
                    count = count + 2;
                }
            }
            Console.WriteLine();

            foreach (string s in Expression)
            {

                if (string.Compare(s, "(") == 0)
                    Operands.Push(s);
                else if (string.Compare(s, ")") == 0)
                {
                    while (Operands.Peek() != "(")
                        Values.Push(PerformOperations(Operands.Pop(), Values.Pop(), Values.Pop()));
                    Operands.Pop();
                }
                else if (s == "^")
                {
                    // Values.Push(PerformOperations(Operands.Pop(), Values.Pop(), Values.Pop()));
                    Operands.Push(s);
                }


                else if (s == "+" || s == "-" || s == "*" || s == "/" || s == "^")
                {
                    while (Operands.Count != 0 && hasPrecedence(s, Operands.Peek()))
                        Values.Push(PerformOperations(Operands.Pop(), Values.Pop(), Values.Pop()));
                    Operands.Push(s);
                }
                else if (IsNumeric(s, out Number))
                    Values.Push(Number);

            }

            while (Operands.Count != 0)
                Values.Push(PerformOperations(Operands.Pop(), Values.Pop(), Values.Pop()));

            return Math.Round(Values.Pop(), 3);

        }
    }
}
