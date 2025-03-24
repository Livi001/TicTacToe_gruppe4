using System;

namespace tictactoe_gruppe4
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hier wird der GameController als Singleton initialisiert
            GameController game = GameController.Instance;
            Console.ReadLine();
        }
    }
}
