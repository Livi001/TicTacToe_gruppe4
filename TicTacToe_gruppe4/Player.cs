namespace tictactoe_gruppe4
{
    public abstract class Player
    {
        public string name;
        public char symbol;


        public Player(string name, char symbol)
        {
            this.name = name;
            this.symbol = symbol;
        }

        /// <summary>
        /// Führt einen Zug aus und gibt eine Beschreibung und die Position des Zuges zurück.
        /// </summary>
        /// <param name="gameBoard">Das aktuelle Spielfeldmodell.</param>
        /// <returns>Ein Tupel aus Beschreibung und Position des Zuges.</returns>

        public abstract (string, (int, int)) MakeMove(GameBoardModel gameBoard);
        /// <summary>
        /// Gibt den Namen des Spielers zurück.
        /// </summary>
        /// <returns>Der Name des Spielers.</returns>

        public string GetName() => name;
        /// <summary>
        /// Gibt das Symbol des Spielers zurück.
        /// </summary>
        /// <returns>Das Symbol des Spielers.</returns>

        public char GetSymbol() => symbol;
    }
}
