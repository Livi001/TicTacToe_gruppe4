using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_gruppe4;

namespace tictactoe_test
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

        private List<string> gameHistory = new List<string>(); // Liste für Spielverlauf

        public enum BoardSize
        {
            Klassik = 3,
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
                1 => (int)BoardSize.Klassik,
                2 => (int)BoardSize.Gross,
                3 => (int)BoardSize.Riesig,
                _ => (int)BoardSize.Klassik
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

                (int row, int col) = currentPlayer.MakeMove(gameBoard);
                string moveDescription = $"{currentPlayer.GetName()} ({currentPlayer.GetSymbol()}) setzt auf [{row}, {col}]";
                LogMove(moveDescription);


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

            // Am Ende des Spiels wird entschieden, ob das Spiel neu startet oder nicht
            EndGame();
        }

        private void SwitchPlayer() => currentPlayer = (currentPlayer == players[0]) ? players[1] : players[0];

        private void EndGame()
        {
            Console.WriteLine("Möchten Sie das Spiel neu starten? (y/n): ");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                RestartGame(); // Spiel neu starten
            }
            else if (choice.ToLower() == "n")
            {
                // Falls der Benutzer nicht neu starten möchte, fragen wir, ob er den Spielverlauf ansehen möchte
                Console.WriteLine("Möchten Sie den Spielverlauf ansehen? (y/n): ");
                string viewHistoryChoice = Console.ReadLine();

                if (viewHistoryChoice.ToLower() == "y")
                {
                    ShowGameHistory(); // Spielverlauf anzeigen
                }
                else
                {
                    Console.WriteLine("Das Spiel wird jetzt beendet.");
                }
            }
        }

        public void RestartGame()
        {
            Console.WriteLine("Das Spiel wird neu gestartet...");
            int boardSize = ChooseBoardSize();
            gameBoard = new GameBoardModel(boardSize);
            currentPlayer = players[0]; // Setze den ersten Spieler zurück
            StartGame(); // Starte das Spiel neu
        }

        // Methode zum Protokollieren eines Zuges
        private void LogMove(string moveDescription)
        {
            gameHistory.Add(moveDescription); // Zug zum Verlauf hinzufügen
        }

        // Methode zum Anzeigen des Spielverlaufs
        public void ShowGameHistory()
        {
            Console.WriteLine("Spielverlauf:");
            foreach (var move in gameHistory)
            {
                Console.WriteLine(move); // Gibt jeden Zug im Verlauf aus
            }
        }
    }
}
