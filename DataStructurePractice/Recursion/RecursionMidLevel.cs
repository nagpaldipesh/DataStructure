using System.Collections.Immutable;
using System.Text;

namespace DataStructurePractice.Recursion {
    internal class RecursionMidLevel {

        //Tower of Hanoi

        public static void TowerOfHanoi(int num, string source, string helper, string dest) {
            if (num > 0) {
                //    Console.WriteLine($"Transfer disk no {num} from {source} to {dest}");

                //    return; 
                //}

                TowerOfHanoi(num - 1, source, dest, helper);
                Console.WriteLine($"Transfer disk no {num} from {source} to {dest}");

                TowerOfHanoi(num - 1, helper, source, dest);
                //Console.WriteLine($"Transfer disk no {num} from {helper} to {dest}");
            }
        }

        public static string ReverseString(string str, string reverseStr = "") {
            if (str.Length == 0) {
                return "";
            }

            int length = str.Length;
            reverseStr = reverseStr + str.Substring(length - 1) + ReverseString(str.Substring(0, length - 1), reverseStr);

            return reverseStr;
        }

        public static void PrintReverseString(string str, int index) {
            if (index < 0)
                return;

            Console.Write(str.ElementAt(index));

            PrintReverseString(str, index - 1);
        }

        int firstOccIndex = -1, lastOccIndex = -1;
        private void CheckFirstAndLastOccurenceOfElement(string str, char element, int index) {
            if (index > (str.Length - 1))
                return;

            if (str[index] == element) {
                if (firstOccIndex < 0) {
                    firstOccIndex = index;
                    lastOccIndex = index;
                }
                else {
                    lastOccIndex = index;
                }
            }

            CheckFirstAndLastOccurenceOfElement(str, element, ++index);
        }

        public void CheckFirstAndLastOccuOfElement(string str, char element) {

            CheckFirstAndLastOccurenceOfElement(str, element, 0);

            Console.WriteLine($"First Occurence of Element {element} is {firstOccIndex} and Last Occurence is {lastOccIndex} ");
        }

        bool isSorted = true;
        private bool IsArrayIsSortedInAcendingOrder(int[] numbers, int index, int lastNumber) {

            if (index == numbers.Length)
                return true;

            int currentNumber = numbers[index];

            if (currentNumber < lastNumber) {
                return false;
            }

            return IsArrayIsSortedInAcendingOrder(numbers, ++index, currentNumber);
        }


        public bool IsArraySortedAcending(int[] numbers) {
            if (numbers.Length == 0)
                return false;

            return IsArrayIsSortedInAcendingOrder(numbers, 1, numbers[0]);

            //return isSorted;
        }

        StringBuilder sb = new StringBuilder();
        StringBuilder elementsb = new StringBuilder();

        public string PlaceElementsAtEnd(string str, char element, int index) {

            if (index == str.Length - 1)
                return str;

            if (str[index] == element) {
                elementsb.Append(element);
            }
            else {
                sb.Append(str[index]);
            }

            PlaceElementsAtEnd(str, element, ++index);

            return sb.ToString() + elementsb.ToString();
        }

        Dictionary<char, int> dict = new Dictionary<char, int>();
        public string RemoveDuplicateCharacters(string str, int index) {
            if (index == str.Length)
                return "";

            var c = str[index];
            if (!dict.ContainsKey(c)) {
                sb.Append(c);
                dict.Add(c, index);
            }
            RemoveDuplicateCharacters(str, index + 1);

            return sb.ToString();
        }

        public void PrintAllSubsequence(string str, int index, string newStr = "") {
            if (index == str.Length) {
                Console.WriteLine(newStr);
                return;
            }
                
            char currentChar = str[index];

            ++index;

            PrintAllSubsequence(str, index, newStr + currentChar );
            PrintAllSubsequence(str, index, newStr);
            //Console.WriteLine();
        }

        HashSet<string> uniquestrings= new HashSet<string>();
        public void PrintUniqueSubsequence(string str, int index, string newStr = "") {
            if (index == str.Length) {
                
                if(!uniquestrings.Contains(newStr)) {
                    Console.WriteLine(newStr);

                    uniquestrings.Add(newStr);
                }
                return;
            }

            char currentChar = str[index];

            ++index;

            PrintUniqueSubsequence(str, index, newStr + currentChar);
            PrintUniqueSubsequence(str, index, newStr);

        }

        string[] keypad = { ".", "abc", "def", "ghi", "jkl", "mno", "pqrs", "to", "uvw", "xyz" };
        public void PrintKeypadCombinations(string str, int index, string newStr = "") {

            if(index == str.Length) {
                    Console.WriteLine(newStr);
                return;
            }

            char currentChar = str[index];

            var num = currentChar - '0';

            var possibleOptions = keypad[num];
            ++index;

            foreach ( var option in possibleOptions ) {
                PrintKeypadCombinations(str, index, newStr + option);
                //PrintKeypadCombinations(str, index, newStr);
            }
        }
    }
}
