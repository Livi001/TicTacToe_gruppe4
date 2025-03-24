using System;

namespace tictactoe_gruppe4
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

        public char GetCell(int row, int col)
        {
            return board[row, col];
        }

        public int GetSize()
        {
            return board.GetLength(0);
        }

        public char[,] GetBoardCopy()
        {
            return (char[,])board.Clone();
        }

        public void SetBoard(char[,] newBoard)
        {
            board = newBoard;
        }

        public bool CheckWin(char symbol)
        {
            int size = GetSize();

            // Zeilen und Spalten prüfen
            for (int i = 0; i < size; i++)
            {
                if (CheckRow(i, symbol) || CheckColumn(i, symbol))
                    return true;
            }

            // Diagonalen prüfen
            if (CheckDiagonal(symbol) || CheckAntiDiagonal(symbol))
                return true;

            return false;
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
            int size = GetSize();
            for (int i = 0; i < size; i++)
            {
                if (board[i, i] != symbol)
                    return false;
            }
            return true;
        }

        private bool CheckAntiDiagonal(char symbol)
        {
            int size = GetSize();
            for (int i = 0; i < size; i++)
            {
                if (board[i, size - i - 1] != symbol)
                    return false;
            }
            return true;
        }

        public bool IsFull()
        {
            foreach (var cell in board)
            {
                if (cell == ' ')
                    return false;
            }
            return true;
        }
    }
}
