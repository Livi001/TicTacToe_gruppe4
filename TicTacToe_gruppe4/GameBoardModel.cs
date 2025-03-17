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
        private int size;

        public GameBoardModel(int size)
        {
            this.size = size;
            board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public char GetCell(int row, int col) => board[row, col];

        public void SetCell(int row, int col, char symbol) => board[row, col] = symbol;

        public int GetSize() => size;

        public bool IsFull()
        {
            foreach (char cell in board)
            {
                if (cell == ' ') return false;
            }
            return true;
        }

        public bool CheckWin(char symbol)
        {
            // Zeilen & Spalten prüfen
            for (int i = 0; i < size; i++)
            {
                if (CheckRow(i, symbol) || CheckColumn(i, symbol)) return true;
            }
            // Diagonalen prüfen
            return CheckDiagonal(symbol) || CheckAntiDiagonal(symbol);
        }

        private bool CheckRow(int row, char symbol)
        {
            for (int col = 0; col < size; col++)
                if (board[row, col] != symbol) return false;
            return true;
        }

        private bool CheckColumn(int col, char symbol)
        {
            for (int row = 0; row < size; row++)
                if (board[row, col] != symbol) return false;
            return true;
        }

        private bool CheckDiagonal(char symbol)
        {
            for (int i = 0; i < size; i++)
                if (board[i, i] != symbol) return false;
            return true;
        }

        private bool CheckAntiDiagonal(char symbol)
        {
            for (int i = 0; i < size; i++)
                if (board[i, size - i - 1] != symbol) return false;
            return true;
        }

        public char[,] GetBoardCopy()
        {
            return (char[,])board.Clone();
        }

    }
}
