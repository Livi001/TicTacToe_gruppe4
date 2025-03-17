using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
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
