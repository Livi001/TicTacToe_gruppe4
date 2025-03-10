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
            Klassisch = 3,
            Gross = 5,
            Riesig = 7
        }

        public GameController(BoardSize size)
        {
            boardSize = (int)size;
            gameBoard = new GameBoardModel(boardSize);
            gameView = new GameView();

            StartGame();
        }

        public void StartGame()
        {
            Console.WriteLine($"Ein {boardSize}x{boardSize} Tic-Tac-Toe-Spiel wurde gestartet!");
            gameView.PrintBoard(gameBoard, boardSize);
        }
    }
}
