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

        /// <summary>
        /// Setzt ein Symbol auf dem Spielfeld.
        /// </summary>
        /// <param name="row">Die Zeile des Spielfelds.</param>
        /// <param name="col">Die Spalte des Spielfelds.</param>
        /// <param name="symbol">Das zu setzende Symbol.</param>

        public void SetCell(int row, int col, char symbol)
        {
            board[row, col] = symbol;
        }
        /// <summary>
        /// Gibt das Symbol an der angegebenen Position zurück.
        /// </summary>
        /// <param name="row">Die Zeile des Spielfelds.</param>
        /// <param name="col">Die Spalte des Spielfelds.</param>
        /// <returns>Das Symbol an der angegebenen Position.</returns>

        public char GetCell(int row, int col)
        {
            return board[row, col];
        }
        /// <summary>
        /// Gibt die Größe des Spielfelds zurück.
        /// </summary>
        /// <returns>Die Größe des Spielfelds.</returns>

        public int GetSize()
        {
            return board.GetLength(0);
        }
        /// <summary>
        /// Gibt eine Kopie des aktuellen Spielfelds zurück.
        /// </summary>
        /// <returns>Eine Kopie des aktuellen Spielfelds.</returns>

        public char[,] GetBoardCopy()
        {
            return (char[,])board.Clone();
        }
        /// <summary>
        /// Setzt das Spielfeld auf einen neuen Zustand.
        /// </summary>
        /// <param name="newBoard">Der neue Zustand des Spielfelds.</param>

        public void SetBoard(char[,] newBoard)
        {
            board = newBoard;
        }
        /// <summary>
        /// Überprüft, ob ein Spieler mit dem angegebenen Symbol gewonnen hat.
        /// </summary>
        /// <param name="symbol">Das Symbol des Spielers.</param>
        /// <returns>True, wenn der Spieler gewonnen hat, andernfalls false.</returns>

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
        /// <summary>
        /// Überprüft, ob das Spielfeld vollständig gefüllt ist.
        /// </summary>
        /// <returns>True, wenn das Spielfeld vollständig gefüllt ist, andernfalls false.</returns>

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
