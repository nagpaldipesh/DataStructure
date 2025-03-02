using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Stack
{
    internal class PostFixEvalution
    {
//        Given a postfix expression, the task is to evaluate the postfix expression.A Postfix expression is of the form “a b operator” (ab+) i.e., a pair of operands is followed by an operator.

//        Examples:

//              Input: str = “2 3 1 * + 9 -“
//              Output: -4
//              Explanation: If the expression is converted into an infix expression, it will be 2 + (3 * 1) – 9 = 5 – 9 = -4.


//              Input: str = “100 200 + 2 / 5 * 7 +”
//              Output: 757

        public static void Execute()
        {
            //PostfixEvalution("23*5+").ShouldBe(11);
            PostfixEvalution("82/4+").ShouldBe(8);
        }

        static int PostfixEvalution(string str)
        {
            Stack<int> stack = new Stack<int>();

            foreach (var c in str)
            {
                if(char.IsDigit(c))
                {
                    int num = c - '0';
                    stack.Push(num);
                }
                else
                {
                    if (stack.Count < 2)
                        throw new InvalidOperationException("Invalid postfix expression");

                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    int result = 0;

                    switch (c)
                    {
                        case '+':
                            result = operand1 + operand2;
                            break;
                        case '-':
                            result = operand1 - operand2;
                            break;
                        case '*':
                            result = operand1 * operand2;
                            break;
                        case '/':
                            result = operand2 > 0 ? operand1 / operand2 : 0;
                            break;
                    }

                    stack.Push(result);
                }
            }

            return stack.Pop();
        }
    }
}
