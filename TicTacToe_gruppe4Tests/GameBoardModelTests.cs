using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe_gruppe4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4.Tests
{
    [TestClass()]
    public class GameBoardModelTests
    {
        [TestMethod()]
        public void GameBoardModelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCellTest()
        {
            GameBoardModel board = new GameBoardModel(3);
            char result = board.GetCell(1, 2);
            Assert.AreEqual(' ', result);
        }

        
    }
}