using System;

namespace tictactoe_gruppe4
{
    public class Timer
    {
        private DateTime startTime;
        /// <summary>
        /// Startet den Timer.
        /// </summary>
        public void Start()
        {
            startTime = DateTime.Now;
        }
        /// <summary>
        /// Stoppt den Timer und gibt die verstrichene Zeit in Sekunden aus.
        /// </summary>

        public void Stop()
        {
            Console.WriteLine($"Spielzeit: {(DateTime.Now - startTime).TotalSeconds} Sekunden.");
        }
    }
}
