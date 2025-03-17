using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    public class GameLogger
    {
        public void LogMove(Move move) => Console.WriteLine($"Zug protokolliert: [{move.Row}, {move.Col}]");

        public void SaveGame() => Console.WriteLine("Spiel gespeichert.");

        public void LoadGame() => Console.WriteLine("Spiel geladen.");
    }
}
