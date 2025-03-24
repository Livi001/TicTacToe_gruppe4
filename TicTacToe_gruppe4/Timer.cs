using System;

namespace tictactoe_gruppe4
{
    public class Timer
    {
        private DateTime startTime;

        public void Start()
        {
            startTime = DateTime.Now;
        }

        public void Stop()
        {
            Console.WriteLine($"Spielzeit: {(DateTime.Now - startTime).TotalSeconds} Sekunden.");
        }
    }
}
