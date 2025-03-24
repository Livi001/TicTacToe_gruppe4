using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_gruppe4;

namespace tictactoe_test
{
    internal class GameView
    {
        public void PrintBoard(GameBoardModel board, int size)
        {
            Console.Clear();
            Console.WriteLine("Tic-Tac-Toe 2.0");

            // Spaltenbezeichner (oben) ausgeben
            Console.Write("     "); // Zusätzliche Einrückung für die Spaltenbezeichner
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i}   "); // Ausrichtung der Spaltenbezeichner
            }
            Console.WriteLine();

            // Spielfeld mit Gitterlinien
            for (int i = 0; i < size; i++)
            {
                // Zeilenbezeichner mit entsprechender Einrückung ausgeben
                Console.Write($"{i}  "); // Formatierung der Zeilenbezeichner

                for (int j = 0; j < size; j++)
                {
                    // Zellen ausgeben, mit einer festen Breite für jede Zelle
                    Console.Write($" {board.GetCell(i, j)} "); // Jede Zelle hat 3 Zeichen Platz

                    // Vertikale Trennlinie nach jeder Zelle, außer der letzten
                    if (j < size - 1)
                        Console.Write("|");
                }

                // Zeilenumbruch nach jeder Zeile
                Console.WriteLine();

                // Horizontale Trennlinie nach jeder Zeile, außer der letzten
                if (i < size - 1)
                {
                    Console.Write("    "); // Einrückung für die Gitterlinie
                    for (int j = 0; j < size - 1; j++)
                    {
                        Console.Write("----"); // Länge der Gitterlinie
                    }
                    Console.WriteLine();
                }
            }
        }




        public void PrintMessage(string message) => Console.WriteLine(message);
    }



}
