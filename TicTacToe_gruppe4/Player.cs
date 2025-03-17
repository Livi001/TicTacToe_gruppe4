using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
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

        public string GetName() => name;
        public char GetSymbol() => symbol;

        public abstract void MakeMove(GameBoardModel gameBoard);
    }
}
