using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_gruppe4
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }

        public override void MakeMove(GameBoardModel gameBoard)
        {
            int row, col;
            bool validMove = false;

            while (!validMove)
            {
                while (true)
                {
                    Console.Write($"{name} ({symbol}), geben Sie Ihre Zeile (0-{gameBoard.GetSize() - 1}) ein: ");
                    if (int.TryParse(Console.ReadLine(), out row)) break;
                    Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine Zahl ein.");
                }

                while (true)
                {
                    Console.Write($"{name} ({symbol}), geben Sie Ihre Spalte (0-{gameBoard.GetSize() - 1}) ein: ");
                    if (int.TryParse(Console.ReadLine(), out col)) break;
                    Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine Zahl ein.");
                }

                if (row >= 0 && row < gameBoard.GetSize() && col >= 0 && col < gameBoard.GetSize() && gameBoard.GetCell(row, col) == ' ')
                {
                    gameBoard.SetCell(row, col, symbol);
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Ungültiger Zug! Bitte erneut eingeben.");
                }
            }
        }
    }
}
