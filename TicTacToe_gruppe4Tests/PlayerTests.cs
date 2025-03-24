using Microsoft.VisualStudio.TestTools.UnitTesting;
using tictactoe_gruppe4;


namespace TicTacToeTests
{
    [TestClass]
    public class HumanPlayerTests
    {
        [TestMethod]
        public void MakeMove_ShouldReturnValidMove()
        {
            // Arrange
            var gameBoard = new GameBoardModel(3);
            var player = new HumanPlayer("Player1", 'X');

            // Act
            // Simulating a valid input
            var move = player.MakeMove(gameBoard);

            // Assert
            Assert.AreEqual("Player1 setzt", move.Item1);
            Assert.IsTrue(gameBoard.GetCell(move.Item2.Item1, move.Item2.Item2) == 'X');
        }
    }
}
