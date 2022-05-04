using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniMonopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game game = new Game();
            game.BuildBoard(); 
            game.GameStart();
            
            // TEST StreetSquare by color
            foreach(var item in StreetSquare.StreetsquaresByColor) {
                Console.WriteLine($"{item.Key}:");
                foreach(var street in item.Value) {
                    Console.ForegroundColor = street.Color;
                    Console.WriteLine(street.Name);
                }
                Console.ResetColor();
                Console.WriteLine("---");
            }
        }
    }
}
