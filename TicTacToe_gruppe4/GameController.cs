using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    internal class GameController
    {
        private GameBoardModel gameBoard;
        private GameView gameView;
        private int boardSize;

        public enum BoardSize
        {
            Classic = 3,
            Gross = 5,
            Riesig = 7
        }

        public GameController()
        {
            boardSize = ChooseBoardSize();
            gameBoard = new GameBoardModel(boardSize);
            gameView = new GameView();

            StartGame();
        }

        private int ChooseBoardSize()
        {
            Console.WriteLine("Wählen Sie die Spielfeldgröße:");
            Console.WriteLine("1. Classic (3x3)");
            Console.WriteLine("2. Groß (5x5)");
            Console.WriteLine("3. Riesig (7x7)");

            int sizeChoice = 0;
            while (sizeChoice < 1 || sizeChoice > 3)
            {
                Console.Write("Bitte wählen Sie 1, 2 oder 3: ");
                sizeChoice = Convert.ToInt32(Console.ReadLine());
            }

            switch (sizeChoice)
            {
                case 1: return (int)BoardSize.Classic;
                case 2: return (int)BoardSize.Gross;
                case 3: return (int)BoardSize.Riesig;
                default: return (int)BoardSize.Classic;
            }
        }

        public void StartGame()
        {
            Console.WriteLine($"Ein {boardSize}x{boardSize} Tic-Tac-Toe-Spiel wurde gestartet!");
            gameView.PrintBoard(gameBoard, boardSize);
        }
    }
}

