using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_24
{
    public class InfixToPostfixConvertor
    {
        public static int Precedence(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;
                
                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        public static string Convert (string exp)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            for(int i=0; i<exp.Length; i++)
            {
                char c = exp[i];

                if (char.IsLetterOrDigit(c)) { stringBuilder.Append(c); }
                else if (c == '(') { stack.Push(c); }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        stringBuilder.Append(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
                    {
                        stringBuilder.Append(stack.Pop());
                    }
                    stack.Push(c);
                }
            }
            while (stack.Count > 0)
            {
                stringBuilder.Append(stack.Pop());
            }

            return stringBuilder.ToString();
        }
    }
}
