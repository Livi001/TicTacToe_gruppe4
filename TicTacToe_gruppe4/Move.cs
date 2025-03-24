using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe_gruppe4
{
    /// <summary>
    /// Initialisiert eine neue Instanz der <see cref="Move"/> Klasse.
    /// </summary>
    /// <param name="row">Die Zeile des Zuges.</param>
    /// <param name="col">Die Spalte des Zuges.</param>

    public class Move
    {
        public int Row { get; }
        public int Col { get; }

        public Move(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }

}
