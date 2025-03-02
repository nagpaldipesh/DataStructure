using System.Text;

namespace DataStructurePractice.String
{
    public class StringProblems
    {

        public static void Execute()
        {

        }

        public static string ReplaceSpaceWithText(string text, string replacedText)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    stringBuilder.Append(replacedText);
                }
                else
                {
                    stringBuilder.Append(text[i]);
                }
            }

            return stringBuilder.ToString();
        }

        // there are three types of edits available that can be performed on the strings. Insert an character remove a character or replace a character. Given two strings, write a 
        // function to check one edit or zero edit
        public static bool OneAway(string input, string modifiedInput)
        {
            int len1 = input.Length, len2 = modifiedInput.Length;

            if (Math.Abs(len1 - len2) > 1)
            {
                return false;
            }

            int i = 0, j = 0;

            bool foundModification = false;

            while (i < len1 && j < len2)
            {
                if (input[i] != modifiedInput[j])
                {
                    if (foundModification)
                        return false;

                    foundModification = true;

                    if (len1 == len2)
                    {
                        i++;
                        j++;
                    }
                    else if (len1 > len2)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
                else
                {
                    i++;
                    j++;
                }
            }

            return true;
        }

        // Implement a method to perform basic string compression using the counts of repeated characters. For example aabcccccaaa would become a2b1c5a3.
        // If the compressed string would not become smaller string then your method should return the original string.
        // You can assume string has only uppercase and lowercase letter (a-z)
        public static string StringCompression(string input)
        {
            if (string.IsNullOrEmpty(input)) return input; // Handle edge case

            char lastChar = input[0];

            StringBuilder sb = new StringBuilder();
            sb.Append(lastChar);

            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == lastChar)
                {
                    count++;
                }
                else
                {
                    sb.Append(count).Append(input[i]);
                    lastChar = input[i];
                    count = 1;
                }
            }

            //Add the last count
            sb.Append(count);

            return sb.Length < input.Length ? sb.ToString() : input;
        }

    }
}
