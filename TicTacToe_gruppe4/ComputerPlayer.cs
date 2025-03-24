using System;
using tictactoe_gruppe4;

namespace tictactoe_gruppe4
{
    public class ComputerPlayer : Player
    {
        private static Random rnd = new Random();

        public ComputerPlayer(string name, char symbol) : base(name, symbol)
        {
        }

        public override (string, (int, int)) MakeMove(GameBoardModel gameBoard)
        {
            int row = -1, col = -1;

            // 1. Versuch zu gewinnen
            if (TryToWin(gameBoard, GetSymbol(), out row, out col))
            {
                gameBoard.SetCell(row, col, GetSymbol());
                Console.WriteLine($"🤖 {GetName()} ({GetSymbol()}) setzt auf [{row}, {col}] (Gewinnzug)");
                return ($"{GetName()} setzt", (row, col));
            }

            // 2. Blockiere, falls der Gegner gewinnen könnte
            if (TryToBlock(gameBoard, out row, out col))
            {
                gameBoard.SetCell(row, col, GetSymbol());
                Console.WriteLine($"🤖 {GetName()} ({GetSymbol()}) setzt auf [{row}, {col}] (Blockzug)");
                return ($"{GetName()} setzt", (row, col));
            }

            // 3. Zufälliger Zug
            do
            {
                row = rnd.Next(0, gameBoard.GetSize());
                col = rnd.Next(0, gameBoard.GetSize());
            } while (gameBoard.GetCell(row, col) != ' ');

            gameBoard.SetCell(row, col, GetSymbol());
            Console.WriteLine($"🤖 {GetName()} ({GetSymbol()}) setzt auf [{row}, {col}] (Zufallszug)");
            return ($"{GetName()} setzt", (row, col));
        }

        private bool TryToWin(GameBoardModel gameBoard, char symbol, out int row, out int col)
        {
            int size = gameBoard.GetSize();
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (gameBoard.GetCell(r, c) == ' ')
                    {
                        gameBoard.SetCell(r, c, symbol);
                        if (gameBoard.CheckWin(symbol))
                        {
                            gameBoard.SetCell(r, c, ' ');
                            row = r;
                            col = c;
                            return true;
                        }
                        gameBoard.SetCell(r, c, ' ');
                    }
                }
            }
            row = -1;
            col = -1;
            return false;
        }

        private bool TryToBlock(GameBoardModel gameBoard, out int row, out int col)
        {
            char opponentSymbol = GetSymbol() == 'X' ? 'O' : 'X';
            int size = gameBoard.GetSize();

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (gameBoard.GetCell(r, c) == ' ')
                    {
                        gameBoard.SetCell(r, c, opponentSymbol);
                        if (gameBoard.CheckWin(opponentSymbol))
                        {
                            gameBoard.SetCell(r, c, ' ');
                            row = r;
                            col = c;
                            return true;
                        }
                        gameBoard.SetCell(r, c, ' ');
                    }
                }
            }
            row = -1;
            col = -1;
            return false;
        }
    }
}
