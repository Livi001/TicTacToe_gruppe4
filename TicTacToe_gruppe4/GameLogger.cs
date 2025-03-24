using System;
using System.IO;


namespace tictactoe_gruppe4
{
    public class GameLogger
    {
        private const string logFile = "game_log.txt";

        public void LogMove(Move move)
        {
            string logEntry = $"Zug protokolliert: [Zeile: {move.Row}, Spalte: {move.Col}]";
            Console.WriteLine(logEntry);
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
        }

        public void SaveGame()
        {
            Console.WriteLine("Spiel gespeichert.");
            // Zusätzliche Logik zum Speichern des Spiels
        }

        public void LoadGame()
        {
            Console.WriteLine("Spiel geladen.");
            // Zusätzliche Logik zum Laden eines Spiels
        }

        public void ClearLog()
        {
            File.WriteAllText(logFile, string.Empty);
        }
    }
}
