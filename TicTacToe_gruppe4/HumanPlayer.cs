using System;

namespace tictactoe_gruppe4
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol)
        {
        }

        public override (string, (int, int)) MakeMove(GameBoardModel gameBoard)
        {
            while (true)
            {
                Console.Write($"{GetName()} ({GetSymbol()}), geben Sie die Zeile (oder 'undo' zum Rückgängig machen) ein: ");
                string inputRow = Console.ReadLine();
                if (inputRow.ToLower() == "undo")
                {
                    GameController.Instance.UndoMove();
                    // Nach dem Undo wird die Schleife fortgesetzt, sodass der Spieler erneut einen Zug eingeben kann.
                    continue;
                }
                if (!int.TryParse(inputRow, out int row))
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein.");
                    continue;
                }

                Console.Write($"{GetName()} ({GetSymbol()}), geben Sie die Spalte (oder 'undo' zum Rückgängig machen) ein: ");
                string inputCol = Console.ReadLine();
                if (inputCol.ToLower() == "undo")
                {
                    GameController.Instance.UndoMove();
                    continue;
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
