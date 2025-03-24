using System;

namespace tictactoe_gruppe4
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        public override (string, (int, int)) MakeMove(GameBoardModel gameBoard)
        {
            while (true)
            {
                Console.Write($"{GetName()} ({GetSymbol()}), geben Sie die Zeile (oder 'undo' zum Rückgängig machen) ein: ");
                string inputRow = Console.ReadLine();

                if (inputRow.ToLower() == "undo")
                {
                    return ("undo", (-1, -1));  // Signalisiert Rückgängig machen
                }

                if (!int.TryParse(inputRow, out int row))
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein.");
                    continue;
                }

                Console.Write($"{GetName()} ({GetSymbol()}), geben Sie die Spalte ein: ");
                string inputCol = Console.ReadLine();

                if (inputCol.ToLower() == "undo")
                {
                    return ("undo", (-1, -1));  // Signalisiert Rückgängig machen
                }

                if (!int.TryParse(inputCol, out int col))
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein.");
                    continue;
                }

                if (row >= 0 && row < gameBoard.GetSize() &&
                    col >= 0 && col < gameBoard.GetSize() &&
                    gameBoard.GetCell(row, col) == ' ')
                {
                    gameBoard.SetCell(row, col, GetSymbol());
                    return ($"{GetName()} setzt", (row, col));
                }
                else
                {
                    Console.WriteLine("Ungültiger Zug, bitte erneut versuchen.");
                }
            }
        }
    }

}

