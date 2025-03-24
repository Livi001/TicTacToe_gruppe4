using System;

namespace tictactoe_gruppe4
{
    public class GameView
    {
        /// <summary>
        /// Zeigt das Spielfeld im Konsolenfenster an.
        /// </summary>
        /// <param name="board">Das aktuelle Spielfeldmodell.</param>
        /// <param name="size">Die Größe des Spielfelds.</param>

        public void PrintBoard(GameBoardModel board, int size)
        {
            Console.Clear();
            Console.WriteLine("Tic-Tac-Toe Extra");
            Console.Write("     ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i}   ");
            }
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i}  ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write($" {board.GetCell(i, j)} ");
                    if (j < size - 1)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (i < size - 1)
                {
                    Console.Write("    ");
                    for (int j = 0; j < size - 1; j++)
                    {
                        Console.Write("----");
                    }
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// Zeigt eine Nachricht im Konsolenfenster an.
        /// </summary>
        /// <param name="message">Die anzuzeigende Nachricht.</param>

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
