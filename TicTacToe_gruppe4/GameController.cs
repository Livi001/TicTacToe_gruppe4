using System;
using System.Collections.Generic;
using tictactoe_gruppe4;

namespace tictactoe_gruppe4
{
    public class GameController
    {
        private GameBoardModel gameBoard;
        private GameView gameView;
        private Player currentPlayer;
        private List<Player> players;
        private static GameController instance;
        private GameLogger gameLogger;
        private Timer gameTimer;
        private GameState gameState;
        private List<string> gameHistory = new List<string>(); // Liste für Spielverlauf
        private Stack<Memento> mementoHistory = new Stack<Memento>(); // Stack für Rückgängig-Machen
        private string logFileName = "game_log.txt";


        public enum BoardSize
        {
            Klassik = 3,
            Gross = 5,
            Riesig = 7
        }

        public GameController()
        {
            // Spielfeldgröße wird nur einmal beim Start des Spiels abgefragt
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
            Console.WriteLine("Wählen Sie die Spielfeldgrösse:");
            Console.WriteLine("1. Classic (3x3)");
            Console.WriteLine("2. Gross (5x5)");
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

                // Der Spieler macht seinen Zug
                (string moveDescription, (int, int) movePosition) = currentPlayer.MakeMove(gameBoard);

                if (moveDescription == "undo") // Überprüfe, ob der Spieler 'undo' eingegeben hat
                {
                    UndoMove();  // Ziehe den letzten Zug zurück
                    continue;    // Lass den aktuellen Spieler denselben Zug erneut ausführen
                }

                LogMove(moveDescription, movePosition); // Spielzug protokollieren

                // Speichern des aktuellen Zustands für Undo
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

                SwitchPlayer(); // Wechsel zum nächsten Spieler
            }

            EndGame();
        }

        private void SwitchPlayer() => currentPlayer = (currentPlayer == players[0]) ? players[1] : players[0];

        // Methode zum Beenden des Spiels
        private void EndGame()
        {
            Console.WriteLine("Möchten Sie das Spiel neu starten oder beenden?");
            Console.WriteLine("1. Neustarten");
            Console.WriteLine("2. Beenden");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                RestartGame(); // Spiel neu starten
            }
            else if (choice == "2")
            {
                Console.WriteLine("Möchten Sie den Spielverlauf ansehen? (y/n): ");
                string viewHistoryChoice = Console.ReadLine();

                if (viewHistoryChoice.ToLower() == "y")
                {
                    ShowGameHistory(); // Spielverlauf anzeigen
                }

                // Beende das Spiel
                Console.WriteLine("Das Spiel wird jetzt beendet.");
                Environment.Exit(0); // Beendet das Programm
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie 1 oder 2.");
                EndGame(); // Falls Eingabe ungültig ist, erneut nach Wahl fragen
            }
        }


        public void RestartGame()
        {
            Console.WriteLine("Das Spiel wird neu gestartet...");

            // Frage, ob die gleichen Spieler verwendet werden sollen
            Console.WriteLine("Möchten Sie die gleichen Spieler wie beim letzten Spiel verwenden? (y/n): ");
            string useSamePlayers = Console.ReadLine().ToLower();

            if (useSamePlayers == "y")
            {
                // Verwende die vorherigen Spieler
                currentPlayer = players[0];
            }
            else
            {
                // Wähle neue Spieler aus
                players = ChoosePlayers();
                currentPlayer = players[0];  // Der erste Spieler wird immer der aktuelle Spieler
            }

            // Spielfeldgröße neu wählen
            int boardSize = ChooseBoardSize();
            gameBoard = new GameBoardModel(boardSize);

            // Verlauf und Mementos leeren (wichtig!)
            gameHistory.Clear();
            mementoHistory.Clear();

            // Spiel starten
            StartGame();
        }




        // Methode zum Protokollieren eines Zuges
        private void LogMove(string moveDescription, (int, int) movePosition)
        {
            string detailedMove = $"{moveDescription} auf [{movePosition.Item1}, {movePosition.Item2}]";
            gameHistory.Add(detailedMove); // Zug zum Verlauf hinzufügen

            // Zeige den Zug in der Konsole an
            Console.WriteLine(detailedMove);

            // Protokolliere den Zug in einer Datei
            LogMoveToFile(detailedMove);  // Aufruf der LogToFile-Methode
        }



        // Methode zum Protokollieren der Züge in einer Datei
        private void LogMoveToFile(string moveDescription)
        {
            try
            {
                Console.WriteLine("Versuche, den Zug in die Datei zu schreiben...");  // Debugging-Ausgabe
                using (StreamWriter writer = new StreamWriter(logFileName, true))  // 'true' bedeutet Anhängen
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {moveDescription}");
                }
                Console.WriteLine("Zug erfolgreich in Datei geschrieben.");  // Debugging-Ausgabe
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Schreiben des Zugs in die Datei: {ex.Message}");  // Fehlerbehandlung
            }
        }


        // Methode zum Anzeigen des Spielverlaufs
        public void ShowGameHistory()
        {
            Console.WriteLine("Spielverlauf:");
            foreach (var move in gameHistory)
            {
                Console.WriteLine(move); // Gibt jeden Zug im Verlauf aus
            }

            // Zeige eine Nachricht, dass das Spielprotokoll in einer Datei gespeichert wurde
            Console.WriteLine("\nDer Spielverlauf wurde auch in der Datei protokolliert.");
        }


        // Methode für Rückgängig-Machen
        public void UndoMove()
        {
            Console.WriteLine($"[Debug] UndoMove aufgerufen. mementoHistory.Count = {mementoHistory.Count}");

            if (mementoHistory.Count > 1)  // Sicherstellen, dass es mehr als einen Zug gibt
            {
                // Entferne den aktuellen Zustand (nach dem letzten Zug)
                mementoHistory.Pop();

                // Stelle den Zustand vor dem letzten Zug wieder her
                Memento previousMemento = mementoHistory.Peek();
                gameBoard.SetBoard(previousMemento.GetSavedState());

                // Entferne den letzten Zug aus gameHistory
                if (gameHistory.Count > 0)
                {
                    gameHistory.RemoveAt(gameHistory.Count - 1); // Letzten Zug entfernen
                }

                Console.WriteLine("Der letzte Zug wurde rückgängig gemacht.");
                RefreshBoard();  // Spielfeld anzeigen

                // Der Spieler darf seinen Zug erneut tätigen
            }
            else
            {
                Console.WriteLine("Es gibt keinen Zug zum Rückgängigmachen.");
            }
        }


        private void RefreshBoard()
        {
            gameView.PrintBoard(gameBoard, gameBoard.GetSize());  // Board wird neu gezeichnet
        }
    }
}
