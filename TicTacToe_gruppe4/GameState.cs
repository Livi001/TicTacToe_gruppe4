using System.Collections.Generic;

namespace tictactoe_gruppe4
{
    public class GameState
    {
        private List<Memento> history = new List<Memento>();
        /// <summary>
        /// Speichert ein Memento im Verlauf.
        /// </summary>
        /// <param name="memento">Das zu speichernde Memento.</param>

        public void SaveMemento(Memento memento)
        {
            history.Add(memento);
        }
        /// <summary>
        /// Gibt das letzte gespeicherte Memento zurück und entfernt es aus dem Verlauf.
        /// </summary>
        /// <returns>Das letzte gespeicherte Memento oder null, wenn der Verlauf leer ist.</returns>

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
