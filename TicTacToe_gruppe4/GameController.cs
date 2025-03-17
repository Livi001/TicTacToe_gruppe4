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
        private Player currentPlayer;
        private List<Player> players;
        private GameLogger gameLogger;
        private Timer gameTimer;
        private GameState gameState;

        public enum BoardSize
        {
            Classic = 3,
            Gross = 5,
            Riesig = 7
        }

        public GameController()
        {
            int boardSize = ChooseBoardSize();
            gameBoard = new GameBoardModel(boardSize);
            gameView = new GameView();
            gameLogger = new GameLogger();
            gameTimer = new Timer();
            gameState = new GameState();

            players = ChoosePlayers();
            currentPlayer = players[0];

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

            return sizeChoice switch
            {
                1 => (int)BoardSize.Classic,
                2 => (int)BoardSize.Gross,
                3 => (int)BoardSize.Riesig,
                _ => (int)BoardSize.Classic
            };
        }

        private List<Player> ChoosePlayers()
        {
            Console.WriteLine("Spieler 1 Name: ");
            string player1Name = Console.ReadLine();
            Console.WriteLine("Spieler 2 Name oder 'KI' für Computer: ");
            string player2Name = Console.ReadLine();

            List<Player> players = new List<Player>
            {
                new HumanPlayer(player1Name, 'X'),
                player2Name.ToLower() == "ki" ? new ComputerPlayer("Computer", 'O') : new HumanPlayer(player2Name, 'O')
            };

            return players;
        }

        public void StartGame()
        {
            gameTimer.Start();
            while (true)
            {
                gameView.PrintBoard(gameBoard, gameBoard.GetSize());

                currentPlayer.MakeMove(gameBoard);
                gameLogger.LogMove(new Move(0, 0)); // Dummy-Wert für Logging

                gameState.SaveMemento(new Memento(gameBoard.GetBoardCopy()));

                if (gameBoard.CheckWin(currentPlayer.GetSymbol()))
                {
                    gameView.PrintBoard(gameBoard, gameBoard.GetSize());
                    Console.WriteLine($"{currentPlayer.GetName()} gewinnt!");
                    gameTimer.Stop();
                    break;
                }

                if (gameBoard.IsFull())
                {
                    gameView.PrintBoard(gameBoard, gameBoard.GetSize());
                    Console.WriteLine("Unentschieden!");
                    gameTimer.Stop();
                    break;
                }

                SwitchPlayer();
            }
        }

        private void SwitchPlayer() => currentPlayer = (currentPlayer == players[0]) ? players[1] : players[0];

        public void UndoMove()
        {
            Memento lastState = gameState.GetLastMemento();
            if (lastState != null)
            {
                Console.WriteLine("Letzter Zug wurde rückgängig gemacht!");
            }
            else
            {
                Console.WriteLine("Kein Zug zum Rückgängig machen!");
            }
        }
    }
}

