using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    public class Timer
    {
        private DateTime startTime;

        public void Start() => startTime = DateTime.Now;
        public void Stop() => Console.WriteLine($"Spielzeit: {(DateTime.Now - startTime).TotalSeconds} Sekunden.");
    }
}
