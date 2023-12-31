using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniMonopoly
{
    class Game
    {
        private List<Square> board = new List<Square>();
        public ImmutableList<Square> Board {
            get {
                return board.ToImmutableList<Square>();
            }
        }
        private List<Player> players = new List<Player>();
        public ImmutableList<Player> Players {
            get {
                return players.ToImmutableList<Player>();
            }
        }
        private byte diceRoll = 0;
        private byte DiceRoll {
            get {
                return this.diceRoll;
            } set {
                this.diceRoll = value;
            }
        }
        private byte diceRollMax = 0;
        private byte DiceRollMax {
            get {
                return this.diceRollMax;
            } set {
                this.diceRollMax = value;
            }
        }
        private int indexOfWinner = 0;
        
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
            
            int colorNumber = 0;
            int rent = 100;
            for(int i = 0; i<streetnames.Length; i++) {
            StreetSquare streetSquare = new StreetSquare(streetnames[i], rent, (ConsoleColor)colorNumber);
                // first and last two squares same color, in between every 3 squares 
                if( ((i%3 == 1)) || (i == 1 || i == streetnames.Length-3)) { 
                    colorNumber++;
                    rent+=10;
                }
            }
            StartSquare startSquare = new StartSquare("GO");
            LotterySquare chanceCard = new LotterySquare("Chance Card", LotterySquare.CardTypes.ChanceCard);
            LotterySquare communityCard = new LotterySquare("Community Card", LotterySquare.CardTypes.CommunityCard);
            board.AddRange(StreetSquare.Streetsquares);
            board.Insert(0, startSquare);
            // Insert LotterySquares at random places
            Utilities.InsertRandomPlace(board, chanceCard);
            Utilities.InsertRandomPlace(board, communityCard);

            //print whole board for test
            // foreach(var item in Board) {
            // Console.WriteLine(item.Name);
            // }

        }
        public void GameStart() {
            Console.WriteLine("Welcome to mini-Monopoly!\nPlease add players (2-8)");
            // Build players
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
            WhoGoesFirst();
            // Start playing!
            StartPlaying();
        }
    
        private void StartPlaying() {
            bool quitGame = false;
            string userInput  = "";
            do {
                foreach(var player in players) {

                    Console.WriteLine("Hit 'enter' to roll your dice! (to quit type 'quit').");
                    userInput = Console.ReadLine();
                    if(userInput.ToLower() == "quit") {
                        quitGame = true;
                        break; //To get out of the foreach without iterating over all players 
                    } else if(userInput == ""){
                        player.Act(board);
                    }
                }
            } while(!quitGame);
        }
        private void WhoGoesFirst() {
            Console.WriteLine("Who goes first? Let the dice decide!");
            Dictionary<Player, byte> playerDiceRolls = new Dictionary<Player, byte>();
    
            foreach(var player in players) {
                Console.WriteLine($"{player.Name} rolling dice");
                Console.Write("rolling dice");
                Utilities.SlowPrintDots();

                // Start dicerolls
                DiceRoll = player.RollDice();
                if(DiceRoll > DiceRollMax) {
                    DiceRollMax = DiceRoll;
                }
                playerDiceRolls.Add(player, DiceRoll);

                Console.WriteLine($"\t{player.Name} rolled {DiceRoll}!");
            }
            // Announce winner
            byte doubleRolls = 0;
            foreach(var playerRoll in playerDiceRolls) {
                if(playerRoll.Value == DiceRollMax) {
                    Console.WriteLine($"Highest roll is {DiceRollMax} by {playerRoll.Key.Name}!");
                    doubleRolls++;
                    indexOfWinner = players.IndexOf(playerRoll.Key);
                    //Highest roller starts -> sort list
                } 
            }
            if(doubleRolls>1) {
                Console.WriteLine("Double rolls, rerolling...!"); //implement 
            }
        }           
    }
}