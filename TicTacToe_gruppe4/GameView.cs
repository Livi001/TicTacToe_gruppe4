using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    internal class GameView
    {

        public void PrintBoard(GameBoardModel board, int size)
        {
            Console.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($" {board.GetCell(i, j)} ");
                    if (j < size - 1) Console.Write("|");
                }
                Console.WriteLine();
                if (i < size - 1) Console.WriteLine(new string('-', size * 4 - 1));
            }
        }
    }
}
