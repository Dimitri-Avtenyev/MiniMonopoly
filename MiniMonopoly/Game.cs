using System;
using System.Collections.Generic;

namespace MiniMonopoly
{
    class Game
    {
        public static List<Square> board = new List<Square>();
        
        // setup streetnames
        private static string[] streetnames = { 
            "Diestsestraat", "Bruul", 
            "Bondgenotenlaan", "Gasthuisstraat", "Leopoldstraat",
            "Lange Zoutstraat", "Vlamingstraat", "Kustlaan",
            "Steenstraat", "Kapellestraat", "Rijselstraat",
            "Leuvensestraat", "Kortrijksestraat", "Grote Markt",
            "Groenplaats", "Lakenstraat", "Veldstraat",
            "Huidevettersstraat", "Vlaanderenstraat", "Demerstraat",
            "Meir", "Nieuwstraat"};
        // build a board -> colors and rent
        public void BuildBoard() {
            List<StreetSquare> test = new List<StreetSquare>();
            int colorNumber = 0;
            int rent = 100;
            for(int i = 0; i<streetnames.Length; i++) {
            StreetSquare streetSquare = new StreetSquare(streetnames[i], rent, (ConsoleColor)colorNumber);
            test.Add(streetSquare);
                // first and last two squares same color, in between every 3 squares 
                if( ((i%3 == 1)) || (i == 1 || i == streetnames.Length-3)) { 
                    colorNumber++;
                    rent+=10;
                }
            }
            // StartSquare startSquare = new StartSquare("GO");
            // board.Add(startSquare);
            // board.AddRange(StreetSquare.Streetsquares);
        }
        public void GameStart() {
            Console.WriteLine("Welcome to mini-Monopoly!\nPlease add players (2-8)");
            // Build players
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
            // Decide who starts
            Console.WriteLine("Who goes first? Let the dice decide!");
            Dictionary<Player, byte> diceRolls = new Dictionary<Player, byte>();
            foreach(var player in players) {
                
                Console.WriteLine($"{player.Name} rolled {player.RollDice()}!");
            }
            
        }
            
    }
}