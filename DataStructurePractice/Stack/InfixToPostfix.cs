
using Shouldly;
using System.Text;

namespace DataStructurePractice.Stack
{
    internal class InfixToPostfixConversion
    {
        //The infix-to-postfix conversion is commonly done using a stack. This algorithm ensures that operators are arranged in the correct order for postfix notation,
        //which makes evaluation straightforward.

        //Operator Precedence Table:
        //    Operator    Precedence      Associativity
        //    -------------------------------------------
        //    + , -	        1	            Left-to-Right
        //    * , /	        2	            Left-to-Right
        //    ^	            3	            Right-to-Left

        public static void Execute()
        {
            Conversion("(A+B)*(C-D)").ShouldBe("AB+CD-*");
            Conversion("A+B*C").ShouldBe("ABC*+");
            Conversion("A+B*C+D").ShouldBe("ABC*+D+");
            Conversion("((A+B)-C*(D/E))+F").ShouldBe("AB+CDE/*-F+");
        }

        static int GetPrecedence(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }

        static string Conversion(string infix)
        {
            StringBuilder postfixSb = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            foreach (char c in infix)
            {
                if (char.IsLetterOrDigit(c))
                {
                    postfixSb.Append(c);
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfixSb = postfixSb.Append(stack.Pop());
                    }
                    stack.Pop(); //Remove (
                }
                else
                {
                    while (stack.Count > 0 && GetPrecedence(stack.Peek()) >= GetPrecedence(c))
                    {
                        postfixSb = postfixSb.Append(stack.Pop());
                    }
                    stack.Push(c);
                }
            }

            while(stack.Count > 0)
            {
                postfixSb.Append(stack.Pop());
            }

            return postfixSb.ToString();
        }
    }
}
