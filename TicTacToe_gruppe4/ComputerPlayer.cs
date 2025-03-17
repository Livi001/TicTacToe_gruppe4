using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    public class ComputerPlayer : Player
    {
        private static Random rnd = new Random();

        public ComputerPlayer(string name, char symbol) : base(name, symbol) { }

        public override void MakeMove(GameBoardModel gameBoard)
        {
            int row, col;
            do
            {
                row = rnd.Next(0, gameBoard.GetSize());
                col = rnd.Next(0, gameBoard.GetSize());
            } while (gameBoard.GetCell(row, col) != ' ');

            gameBoard.SetCell(row, col, symbol);
            Console.WriteLine($"{name} ({symbol}) setzt auf [{row}, {col}]");
        }
    }
}
