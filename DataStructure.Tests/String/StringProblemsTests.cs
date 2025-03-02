using DataStructurePractice.String;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Tests.String
{
    [TestFixture]
    public class StringProblemsTests
    {

        [TestCase("Hello World", "_", "Hello_World")]
        [TestCase("Replace space example", "-", "Replace-space-example")]
        [TestCase("URL encoding test", "%20", "URL%20encoding%20test")]
        [TestCase("Google search query", "+", "Google+search+query")]
        [TestCase("Custom separator", "___", "Custom___separator")]
        public void Test_ReplaceSpaceWithText(string input, string replaceText, string expectedOutput)
        {
            var output = StringProblems.ReplaceSpaceWithText(input, replaceText);

            output.ShouldBe(expectedOutput);
        }

        [TestCase("pale", "pal", true)]
        [TestCase("pales", "pale", true)]
        [TestCase("pale", "bale", true)]
        [TestCase("pale", "bake", false)]
        public void OneAway_Test(string input, string oneAwayText, bool expectedValue)
        {
            StringProblems.OneAway(input, oneAwayText).ShouldBe(expectedValue);
        }

        [TestCase("aabcccccaaa", "a2b1c5a3")]
        [TestCase("abc", "abc")]
        [TestCase("aabbcc", "aabbcc")]
        [TestCase("aaabbbccc", "a3b3c3")]
        public void StringCompression_Test(string input, string expectedOutput)
        {
            StringProblems.StringCompression(input).ShouldBe(expectedOutput);
        }

    }
}
