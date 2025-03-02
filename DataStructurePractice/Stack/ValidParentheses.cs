using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Stack
{
    public class ValidParentheses
    {
        public static void Execute()
        {
            IsParenthesesAreValid("[{()}]").ShouldBeTrue();
            IsParenthesesAreValid("[()()]{}").ShouldBeTrue();
            IsParenthesesAreValid("[()()]").ShouldBeTrue();
            IsParenthesesAreValid("[()(]").ShouldBeFalse();
            IsParenthesesAreValid("[()").ShouldBeFalse();
            IsParenthesesAreValid("([{]})").ShouldBeFalse();
            IsParenthesesAreValid("(abc)").ShouldBeTrue();
        }
        //Given a string s representing an expression containing various types of brackets: {}, (), and[], the task is to determine whether the brackets in the expression
        //are balanced or not.A balanced expression is one where every opening bracket has a corresponding closing bracket in the correct order.

        static bool IsParenthesesAreValid(string input)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ')' || input[i] == '}' || input[i] == ']')
                {
                    if (stack.Count == 0)
                        return false;

                    char poppedItem = stack.Pop();

                    if ((input[i] == ')' && poppedItem != '(') || (input[i] == '}' && poppedItem != '{') || (input[i] == ']' && poppedItem != '['))
                    {
                        return false;
                    }
                }
                else if(input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
            }

            return stack.Count == 0;
        }
    }
}
