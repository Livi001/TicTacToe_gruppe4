namespace tictactoe_gruppe4
{
    public class Memento
    {
        private char[,] boardState;

        public Memento(char[,] state)
        {
            boardState = (char[,])state.Clone();
        }
        /// <summary>
        /// Gibt den gespeicherten Zustand des Spielfelds zurück.
        /// </summary>
        /// <returns>Der gespeicherte Zustand des Spielfelds.</returns>

        public char[,] GetSavedState()
        {
            return (char[,])boardState.Clone();
        }
    }
}
