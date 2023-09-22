//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Project2_Group_24
//{
//    public class ExpressionEvaluation
//    {
//        public static double EvaluatePrefix(string prefix)
//        {
//            Stack<double> stack = new Stack<double>();

//            for (int i = prefix.Length - 1; i >= 0; i--)
//            {
//                char c = prefix[i];

//                if (Char.IsLetterOrDigit(c))
//                {
//                    stack.Push(Char.GetNumericValue(c));
//                }
//                else
//                {
//                    double operand1 = stack.Pop();
//                    double operand2 = stack.Pop();

//                    switch (c)
//                    {
//                        case '+':
//                            stack.Push(operand1 + operand2);
//                            break;
//                        case '-':
//                            stack.Push(operand1 - operand2);
//                            break;
//                        case '*':
//                            stack.Push(operand1 * operand2);
//                            break;
//                        case '/':
//                            stack.Push(operand1 / operand2);
//                            break;
//                    }
//                }
//            }

//            return stack.Pop();
//        }

//        public static double EvaluatePostfix(string postfix)
//        {
//            Stack<double> stack = new Stack<double>();

//            for (int i = 0; i < postfix.Length; i++)
//            {
//                char c = postfix[i];

//                if (Char.IsLetterOrDigit(c))
//                {
//                    stack.Push(Char.GetNumericValue(c));
//                }
//                else
//                {
//                    double operand2 = stack.Pop();
//                    double operand1 = stack.Pop();

//                    switch (c)
//                    {
//                        case '+':
//                            stack.Push(operand1 + operand2);
//                            break;
//                        case '-':
//                            stack.Push(operand1 - operand2);
//                            break;
//                        case '*':
//                            stack.Push(operand1 * operand2);
//                            break;
//                        case '/':
//                            stack.Push(operand1 / operand2);
//                            break;
//                    }
//                }
//            }

//            return stack.Pop();
//        }
//    }
//}
