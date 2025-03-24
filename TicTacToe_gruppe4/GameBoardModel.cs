using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe_test
{
    public class GameBoardModel
    {
        private char[,] board;

        public GameBoardModel(int size)
        {
            board = new char[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board[i, j] = ' ';
        }

        public void SetCell(int row, int col, char symbol)
        {
            board[row, col] = symbol;
        }

        public char GetCell(int row, int col) => board[row, col];

        public int GetSize() => board.GetLength(0);

        // Methode zum Setzen des gesamten Boards
        public void SetBoard(char[,] newBoard)
        {
            board = newBoard; // Das gesamte Spielfeld wird ersetzt
        }

        public bool CheckWin(char symbol)
        {
            int size = GetSize();

            // Horizontale und vertikale Zeilen
            for (int i = 0; i < size; i++)
            {
                if (CheckRow(i, symbol) || CheckColumn(i, symbol))
                    return true;
            }

            // Diagonalen
            if (CheckDiagonal(symbol) || CheckAntiDiagonal(symbol))
                return true;

            return false;
        }

        public bool IsFull()
        {
            foreach (var cell in board)
                if (cell == ' ') return false;

            return true;
        }

        private bool CheckRow(int row, char symbol)
        {
            for (int col = 0; col < GetSize(); col++)
            {
                if (board[row, col] != symbol)
                    return false;
            }
            return true;
        }

        private bool CheckColumn(int col, char symbol)
        {
            for (int row = 0; row < GetSize(); row++)
            {
                if (board[row, col] != symbol)
                    return false;
            }
            return true;
        }

        private bool CheckDiagonal(char symbol)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                if (board[i, i] != symbol)
                    return false;
            }
            return true;
        }

        private bool CheckAntiDiagonal(char symbol)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                if (board[i, GetSize() - i - 1] != symbol)
                    return false;
            }
            return true;
        }

        public char[,] GetBoardCopy()
        {
            return (char[,])board.Clone();
        }
    }

}
