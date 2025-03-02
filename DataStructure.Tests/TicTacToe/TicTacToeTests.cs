using NUnit.Framework;
using DataStructurePractice.Mix.TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class TicTacToeTests
    {
        private TicTacToe _game;

        [SetUp]
        public void SetUp()
        {
            _game = new TicTacToe();
        }

        [Test]
        public void TestMakeMove_ValidMove_ShouldReturnTrue()
        {
            bool result = _game.MakeMove(0, 0, 'X');
            Assert.IsTrue(result);
        }

        [Test]
        public void TestMakeMove_InvalidMove_ShouldReturnFalse()
        {
            _game.MakeMove(0, 0, 'X');
            bool result = _game.MakeMove(0, 0, 'O'); // Same spot
            Assert.IsFalse(result);
        }

        [Test]
        public void TestCheckWinner_Rows_ShouldReturnWinner()
        {
            _game.MakeMove(0, 0, 'X');
            _game.MakeMove(0, 1, 'X');
            _game.MakeMove(0, 2, 'X'); // X wins in the first row

            string result = _game.CheckWinner();
            Assert.AreEqual("Player X Won", result);
        }

        [Test]
        public void TestCheckWinner_Columns_ShouldReturnWinner()
        {
            _game.MakeMove(0, 0, 'O');
            _game.MakeMove(1, 0, 'O');
            _game.MakeMove(2, 0, 'O'); // O wins in the first column

            string result = _game.CheckWinner();
            Assert.AreEqual("Player O Won", result);
        }

        [Test]
        public void TestCheckWinner_Diagonals_ShouldReturnWinner()
        {
            _game.MakeMove(0, 0, 'X');
            _game.MakeMove(1, 1, 'X');
            _game.MakeMove(2, 2, 'X'); // X wins diagonally

            string result = _game.CheckWinner();
            Assert.AreEqual("Player X Won", result);
        }

        [Test]
        public void TestCheckWinner_Draw_ShouldReturnDraw()
        {
            // Filling the board with a draw scenario
            _game.MakeMove(0, 0, 'X');
            _game.MakeMove(0, 1, 'O');
            _game.MakeMove(0, 2, 'X');
            _game.MakeMove(1, 0, 'O');
            _game.MakeMove(1, 1, 'X');
            _game.MakeMove(1, 2, 'O');
            _game.MakeMove(2, 0, 'O');
            _game.MakeMove(2, 1, 'X');
            _game.MakeMove(2, 2, 'O'); // Draw scenario

            string result = _game.CheckWinner();
            Assert.AreEqual("Draw", result);
        }

        [Test]
        public void TestCheckWinner_Ongoing_ShouldReturnOngoing()
        {
            _game.MakeMove(0, 0, 'X');
            _game.MakeMove(0, 1, 'O');

            string result = _game.CheckWinner();
            Assert.AreEqual("Ongoing", result);
        }

        //[Test]
        //public void TestPrintBoard_BoardState_ShouldBePrintedCorrectly()
        //{
        //    _game.MakeMove(0, 0, 'X');
        //    _game.MakeMove(1, 1, 'O');

        //    // Here, we will check the console output. We can redirect the console output to a string.
        //    using (var sw = new System.IO.StringWriter())
        //    {
        //        Console.SetOut(sw);
        //        _game.P();
        //        var output = sw.ToString().Trim();

        //        string expectedOutput = "X |   |   \n---------\n  | O |   \n---------\n  |   |   ";
        //        Assert.AreEqual(expectedOutput, output);
        //    }
        //}
    }
}
