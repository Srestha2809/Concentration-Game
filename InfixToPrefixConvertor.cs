
using System.Text;

public class InfixToPrefixConvertor
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

    public static string Convert(string exp)
    {
        string inputReversed = ReverseString(exp);
        StringBuilder result = new StringBuilder();
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < inputReversed.Length; ++i)
        {
            char c = inputReversed[i];

            if (char.IsLetterOrDigit(c))
            {
                result.Append(c);
            }
            else if (c == ')')
            {
                stack.Push(c);
            }
            else if (c == '(')
            {
                while (stack.Count > 0 && stack.Peek() != ')')
                {
                    result.Append(stack.Pop());
                }
                stack.Pop();
            }
            else
            {
                while (stack.Count > 0 && Precedence(c) < Precedence(stack.Peek()))
                {
                    result.Append(stack.Pop());
                }
                stack.Push(c);
            }
        }

        while (stack.Count > 0)
        {
            result.Append(stack.Pop());
        }

        return ReverseString(result.ToString());
    }

    private static string ReverseString(string str)
    {
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
