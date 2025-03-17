using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    public class GameState
    {
        private List<Memento> history = new List<Memento>();

        public void SaveMemento(Memento memento)
        {
            history.Add(memento);
        }

        public Memento GetLastMemento()
        {
            if (history.Count > 0)
            {
                Memento lastMemento = history[history.Count - 1];
                history.RemoveAt(history.Count - 1);
                return lastMemento;
            }
            return null;
        }
    }
}
