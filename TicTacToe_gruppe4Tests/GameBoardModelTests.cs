using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe_gruppe4; 
using tictactoe_gruppe4;

namespace TicTacToe_gruppe4.Tests
{
    [TestClass]
    public class GameBoardModelTests
    {
        [TestMethod]
        public void SetAndGetCell_ShouldWorkCorrectly()
        {
            // Arrange
            var gameBoard = new GameBoardModel(3);

            // Act
            gameBoard.SetCell(0, 0, 'X');
            var result = gameBoard.GetCell(0, 0);

            // Assert
            Assert.AreEqual('X', result);
        }

        [TestMethod]
        public void CheckWin_ShouldReturnTrue_WhenThereIsAWinnerInRow()
        {
            // Arrange
            var gameBoard = new GameBoardModel(3);
            gameBoard.SetCell(0, 0, 'X');
            gameBoard.SetCell(0, 1, 'X');
            gameBoard.SetCell(0, 2, 'X');

            // Act
            var result = gameBoard.CheckWin('X');

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckWin_ShouldReturnFalse_WhenThereIsNoWinnerInRow()
        {
            // Arrange
            var gameBoard = new GameBoardModel(3);
            gameBoard.SetCell(0, 0, 'X');
            gameBoard.SetCell(0, 1, 'O');
            gameBoard.SetCell(0, 2, 'X');

            // Act
            var result = gameBoard.CheckWin('X');

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFull_ShouldReturnTrue_WhenBoardIsFull()
        {
            // Arrange
            var gameBoard = new GameBoardModel(3);
            gameBoard.SetCell(0, 0, 'X');
            gameBoard.SetCell(0, 1, 'O');
            gameBoard.SetCell(0, 2, 'X');
            gameBoard.SetCell(1, 0, 'X');
            gameBoard.SetCell(1, 1, 'O');
            gameBoard.SetCell(1, 2, 'X');
            gameBoard.SetCell(2, 0, 'O');
            gameBoard.SetCell(2, 1, 'X');
            gameBoard.SetCell(2, 2, 'O');

            // Act
            var result = gameBoard.IsFull();

            // Assert
            Assert.IsTrue(result);
        }
    }

}

