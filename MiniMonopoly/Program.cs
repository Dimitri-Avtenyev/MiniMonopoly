using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniMonopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to mini-Monopoly!\nPlease add players (2-8)");
            //Initialize players
            List<Player> players = new List<Player>();
            do {
                Console.WriteLine($"Name player {players.Count+1}?");
                string playerInput = Console.ReadLine();
                Player player = new Player(playerInput);
                players.Add(player);

            } while(players.Count <2 || Utilities.AskYesOrNo("Add another player?"));
            foreach(var player in players) {
                Console.WriteLine(player.Name);
            }
            // setup streetnames
            string[] streetnames = { //another class? -> StreetEdition
                "Diestsestraat", "Bruul", 
                "Bondgenotenlaan", "Gasthuisstraat", "Leopoldstraat",
                "Lange Zoutstraat", "Vlamingstraat", "Kustlaan",
                "Steenstraat", "Kapellestraat", "Rijselstraat",
                "Leuvensestraat", "Kortrijksestraat", "Grote Markt",
                "Groenplaats", "Lakenstraat", "Veldstraat",
                "Huidevettersstraat", "Vlaanderenstraat", "Demerstraat",
                "Meir", "Nieuwstraat"};
            // build a board -> colors and rent
            //List<StreetSquare> board = new List<StreetSquare>();
            
            int colorNumber = 0;
            int rent = 100;
            for(int i = 0; i<streetnames.Length; i++) {
               StreetSquare streetSqueare = new StreetSquare(streetnames[i], rent, (ConsoleColor)colorNumber);
                // first and last two squares same color, in between every 3 squares 
                if( ((i%3 == 1)) || (i == 1 || i == streetnames.Length-3)) { 
                    colorNumber++;
                    rent+=10;
                } 
            }
 
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
