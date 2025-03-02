namespace DataStructurePractice.Recursion {
    internal class RecurssionAdvanceLevel {

        //public void PrintPermutationsOfString(char[] str, int index) {

        //    if (index == str.Length - 1) {
        //        //var s = str.ToString();
        //        Console.WriteLine(new string(str));

        //        return;
        //    }

        //    //var currentChar = str[index];

        //    IterateAndGenerateString(str, index);
        //    //PrintPermutationsOfString(str, index + 1, newStr + currentChar);
        //    //PrintPermutationsOfString(str, index + 1, currentChar + newStr);
        //}

        //private void IterateAndGenerateString(char[] str, int index) {
        //    if (index < str.Length) {
        //        Swap(ref str[index], ref str[index + 1]);
        //        PrintPermutationsOfString(str, index + 1);
        //        Swap(ref str[index], ref str[index + 1]);
        //    }
        //}

        //private void Swap(ref char a, ref char b) {
        //    var temp = a;
        //    a = b;
        //    b = temp;
        //}

        public void PrintPermutationsOfString(char[] charArray, int index) {
            if (index == charArray.Length - 1) {
                Console.WriteLine(new string(charArray));
                return;
            }

            IterateAndPermute(charArray, index);
        }

        private void IterateAndPermute(char[] charArray, int index) {
            if (index < charArray.Length) {
                Swap(ref charArray[index], ref charArray[index + 1]);
                PrintPermutationsOfString(charArray, index + 1);
                Swap(ref charArray[index], ref charArray[index + 1]); // Backtrack
            }
        }

        static void Swap(ref char a, ref char b) {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}
