namespace tictactoe_gruppe4
{
    public class Memento
    {
        private char[,] boardState;

        public Memento(char[,] state)
        {
            boardState = (char[,])state.Clone();
        }

        public char[,] GetSavedState()
        {
            return (char[,])boardState.Clone();
        }
    }
}
