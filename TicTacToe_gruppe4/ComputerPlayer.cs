using System;

namespace tictactoe_test
{
    public class ComputerPlayer : Player
    {
        private static Random rnd = new Random();

        public ComputerPlayer(string name, char symbol) : base(name, symbol) { }

        public override (int, int) MakeMove(GameBoardModel gameBoard)
        {
            int row, col;

            // 1️⃣ Versuche zu gewinnen
            if (TryToWin(gameBoard, GetSymbol(), out row, out col))
            {
                gameBoard.SetCell(row, col, GetSymbol());
                Console.WriteLine($"🤖 {GetName()} ({GetSymbol()}) setzt auf [{row}, {col}] (Gewinnzug)");
                return (row, col);
            }

            // 2️⃣ Blockiere, wenn Gegner gewinnen kann
            if (TryToBlock(gameBoard, out row, out col))
            {
                gameBoard.SetCell(row, col, GetSymbol());
                Console.WriteLine($"🤖 {GetName()} ({GetSymbol()}) setzt auf [{row}, {col}] (Blockzug)");
                return (row, col);
            }

            // 3️⃣ Zufälliger Zug
            do
            {
                row = rnd.Next(0, gameBoard.GetSize());
                col = rnd.Next(0, gameBoard.GetSize());
            } while (gameBoard.GetCell(row, col) != ' ');

            gameBoard.SetCell(row, col, GetSymbol());
            Console.WriteLine($"🤖 {GetName()} ({GetSymbol()}) setzt auf [{row}, {col}] (Zufallszug)");
            return (row, col); // ✅ Richtige Rückgabe!
        }

        private bool TryToWin(GameBoardModel gameBoard, char symbol, out int row, out int col)
        {
            for (int r = 0; r < gameBoard.GetSize(); r++)
            {
                for (int c = 0; c < gameBoard.GetSize(); c++)
                {
                    if (gameBoard.GetCell(r, c) == ' ')
                    {
                        gameBoard.SetCell(r, c, symbol);
                        if (gameBoard.CheckWin(symbol))
                        {
                            gameBoard.SetCell(r, c, ' '); // Rückgängig machen
                            row = r;
                            col = c;
                            return true;
                        }
                        gameBoard.SetCell(r, c, ' '); // Rückgängig machen
                    }
                }
            }
            row = col = -1;
            return false;
        }

        private bool TryToBlock(GameBoardModel gameBoard, out int row, out int col)
        {
            char opponentSymbol = GetSymbol() == 'X' ? 'O' : 'X';

            for (int r = 0; r < gameBoard.GetSize(); r++)
            {
                for (int c = 0; c < gameBoard.GetSize(); c++)
                {
                    if (gameBoard.GetCell(r, c) == ' ')
                    {
                        gameBoard.SetCell(r, c, opponentSymbol);
                        if (gameBoard.CheckWin(opponentSymbol))
                        {
                            gameBoard.SetCell(r, c, ' '); // Rückgängig machen
                            row = r;
                            col = c;
                            return true;
                        }
                        gameBoard.SetCell(r, c, ' '); // Rückgängig machen
                    }
                }
            }
            row = col = -1;
            return false;
        }
    }
}
