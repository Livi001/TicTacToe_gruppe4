using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    public class GameBoardModel
    {
        private char[,] board;


        public GameBoardModel(int size)
        {
            board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
        public char GetCell(int row, int col)
        {
            return board[row, col];
        }

        public void SetCell(int row, int col, char symbol)
        {
            board[row, col] = symbol;
        } 
    }
}
