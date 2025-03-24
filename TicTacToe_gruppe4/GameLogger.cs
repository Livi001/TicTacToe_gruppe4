using System;
using System.IO;


namespace tictactoe_gruppe4
{
    public class GameLogger
    {
        private const string logFile = "game_log.txt";
        /// <summary>
        /// Protokolliert einen Zug.
        /// </summary>
        /// <param name="move">Der zu protokollierende Zug.</param>

        public void LogMove(Move move)
        {
            string logEntry = $"Zug protokolliert: [Zeile: {move.Row}, Spalte: {move.Col}]";
            Console.WriteLine(logEntry);
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
        }

        /// <summary>
        /// Speichert das Spiel.
        /// </summary>

        public void SaveGame()
        {
            Console.WriteLine("Spiel gespeichert.");
            // Zusätzliche Logik zum Speichern des Spiels
        }
        /// <summary>
        /// Lädt ein gespeichertes Spiel.
        /// </summary>

        public void LoadGame()
        {
            Console.WriteLine("Spiel geladen.");
            // Zusätzliche Logik zum Laden eines Spiels
        }
        /// <summary>
        /// Löscht das Protokoll.
        /// </summary>

        public void ClearLog()
        {
            File.WriteAllText(logFile, string.Empty);
        }
    }
}
