using System;
using TicTacToe_gruppe4;

namespace tictactoe_test
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        public override (int, int) MakeMove(GameBoardModel gameBoard)
        {
            int row, col;
            bool validMove = false;

            while (!validMove)
            {
                Console.Write($"{GetName()} ({GetSymbol()}), geben Sie Ihre Zeile (0-{gameBoard.GetSize() - 1}) ein: ");
                if (!int.TryParse(Console.ReadLine(), out row))
                {
                    Console.WriteLine("❌ Ungültige Eingabe! Bitte eine Zahl eingeben.");
                    continue;
                }

                Console.Write($"{GetName()} ({GetSymbol()}), geben Sie Ihre Spalte (0-{gameBoard.GetSize() - 1}) ein: ");
                if (!int.TryParse(Console.ReadLine(), out col))
                {
                    Console.WriteLine("❌ Ungültige Eingabe! Bitte eine Zahl eingeben.");
                    continue;
                }

                if (row >= 0 && row < gameBoard.GetSize() && col >= 0 && col < gameBoard.GetSize() && gameBoard.GetCell(row, col) == ' ')
                {
                    gameBoard.SetCell(row, col, GetSymbol());
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("❌ Ungültiger Zug! Bitte erneut eingeben.");
                }
            }

            return (row, col); // ✅ Richtige Rückgabe!
        }
    }
}
