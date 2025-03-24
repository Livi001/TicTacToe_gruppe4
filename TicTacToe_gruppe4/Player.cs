using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_gruppe4;

namespace tictactoe_test
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

        // ✅ Methode MakeMove gibt jetzt (int, int) zurück
        public abstract (int, int) MakeMove(GameBoardModel gameBoard);

        // ✅ Getter-Methoden hinzufügen
        public string GetName()
        {
            return name;
        }

        public char GetSymbol()
        {
            return symbol;
        }
    }




}
