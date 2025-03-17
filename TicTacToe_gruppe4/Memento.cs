using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    public class Memento
    {
        private char[,] boardState;

        public Memento(char[,] state)
        {
            boardState = (char[,])state.Clone(); // Kopie des Spielbretts speichern
        }

        public char[,] GetSavedState()
        {
            return (char[,])boardState.Clone(); // Kopie zurückgeben
        }
    }
}
