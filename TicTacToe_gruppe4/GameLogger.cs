using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_gruppe4;

namespace tictactoe_test
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
            // Hier könnte man zusätzliche Logik hinzufügen, um das gesamte Spiel zu speichern.
        }

        public void LoadGame()
        {
            Console.WriteLine("Spiel geladen.");
            // Hier könnte man zusätzliche Logik hinzufügen, um ein gespeichertes Spiel zu laden.
        }

        public void ClearLog()
        {
            File.WriteAllText(logFile, string.Empty); // Löscht die Datei, falls man das Spiel zurücksetzen will.
        }
    }

}
