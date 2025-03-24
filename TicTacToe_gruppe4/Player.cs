namespace tictactoe_gruppe4
{
    public abstract class Player
    {
        protected string name;
        protected char symbol;

        public Player(string name, char symbol)
        {
            this.name = name;
            this.symbol = symbol;
        }

        // Muss ein Tupel (Beschreibung, (Zeile, Spalte)) zurückgeben
        public abstract (string, (int, int)) MakeMove(GameBoardModel gameBoard);

        public string GetName() => name;
        public char GetSymbol() => symbol;
    }
}
