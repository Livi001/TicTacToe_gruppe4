using System;
using System.Collections.Generic;

namespace tictactoe_gruppe4
{
    internal class GameController
    {
        private GameBoardModel gameBoard;
        private GameView gameView;
        private Player currentPlayer;
        private List<Player> players;
        private static GameController instance;
        private GameLogger gameLogger;
        private Timer gameTimer;
        private GameState gameState;
        private List<string> gameHistory = new List<string>(); // Spielverlauf
        private Stack<Memento> mementoHistory = new Stack<Memento>(); // Für Rückgängig-Machen

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

        public static GameController Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameController();
                return instance;
            }
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

                // Erwartet wird, dass MakeMove ein Tupel (string, (int, int)) zurückgibt.
                var moveResult = currentPlayer.MakeMove(gameBoard);
                LogMove(moveResult.Item1, moveResult.Item2); // Zug protokollieren

                // Speichere den aktuellen Zustand für Undo
                gameState.SaveMemento(new Memento(gameBoard.GetBoardCopy()));
                mementoHistory.Push(new Memento(gameBoard.GetBoardCopy()));

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

            EndGame();
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == players[0]) ? players[1] : players[0];
        }

        private void EndGame()
        {
            Console.WriteLine("Möchten Sie das Spiel neu starten? (y/n): ");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                RestartGame();
            }
            else if (choice.ToLower() == "n")
            {
                Console.WriteLine("Möchten Sie den Spielverlauf ansehen? (y/n): ");
                string viewHistoryChoice = Console.ReadLine();

                if (viewHistoryChoice.ToLower() == "y")
                {
                    ShowGameHistory();
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
            currentPlayer = players[0];
            StartGame();
        }

        // Protokolliert den Zug: Erwartet eine Beschreibung (string) und die Position als Tupel (int, int)
        private void LogMove(string moveDescription, (int, int) movePosition)
        {
            string detailedMove = $"{moveDescription} auf [{movePosition.Item1}, {movePosition.Item2}]";
            gameHistory.Add(detailedMove);
            Console.WriteLine(detailedMove);
        }

        public void ShowGameHistory()
        {
            Console.WriteLine("Spielverlauf:");
            foreach (string move in gameHistory)
            {
                Console.WriteLine(move);
            }
        }

        // Eine einzige öffentliche Methode zum Rückgängigmachen
        public void UndoMove()
        {
            // Es müssen mindestens zwei Zustände vorhanden sein:
            // den Zustand vor dem letzten Zug und den aktuellen Zustand.
            if (mementoHistory.Count > 1)
            {
                // Entferne den aktuellen Zustand (nach dem letzten Zug)
                mementoHistory.Pop();
                // Stelle den Zustand vor dem letzten Zug wieder her
                Memento previousMemento = mementoHistory.Peek();
                gameBoard.SetBoard(previousMemento.GetSavedState());
                Console.WriteLine("Der letzte Zug wurde rückgängig gemacht.");
            }
            else
            {
                Console.WriteLine("Es gibt keinen Zug zum Rückgängigmachen.");
            }
        }
    }
}
