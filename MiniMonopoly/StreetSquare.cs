using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniMonopoly
{
    class StreetSquare : Square
    {   //should implement cost of street -> different from rent
        private int rent;
        public int Rent {
            get {
                return this.rent*TotalHouses;
            } set {
                if(value >= 0) {
                    this.rent = value;
                } else {
                    Console.WriteLine("Rent cannot be negative");
                }
            }
        }
        private bool owned = false;
        public bool Owned {
            get {
                return this.owned;
            } set {
                owned = value;
            }
        }
        private Player owner;
        public Player Owner {
            get {
                return this.owner;
            } set {
                owner = value;
            }
        }
        private ConsoleColor color;
        public ConsoleColor Color {
            get {
                return this.color;
            } set {
                this.color = value;
            }
        }
        private int houseCost = 200;
        public int HouseCost {
            get {
                return this.houseCost;
            } private set {
                this.houseCost = value;
            }
        }
        private int totalHouses = 1;
        public int TotalHouses {
            get {
                return this.totalHouses;
            } private set {
                this.totalHouses = value;
            }
        }
        private static List<StreetSquare> streetsquares = new List<StreetSquare>();
        public static ImmutableList<StreetSquare> Streetsquares {
            get {
                List<StreetSquare> tempStreetsquares = new List<StreetSquare>();
                foreach(var item in streetsquaresByColor) {
                    foreach(var streetObj in item.Value) {
                        tempStreetsquares.Add(streetObj);
                    }
                }
                return tempStreetsquares.ToImmutableList();
            }
        }
        private static Dictionary<ConsoleColor, List<StreetSquare>> streetsquaresByColor = new Dictionary<ConsoleColor, List<StreetSquare>>();
        public static ImmutableDictionary<ConsoleColor, List<StreetSquare>> StreetsquaresByColor {
            get {
                return streetsquaresByColor.ToImmutableDictionary();
            }
        }
        public StreetSquare(string name, int rent,  ConsoleColor color):base(name) {
            this.rent = rent;
            this.Color = color;
            List<StreetSquare> dictStreetSquares = new List<StreetSquare>();
            if(!streetsquaresByColor.ContainsKey(color)) {
                streetsquaresByColor.Add(color, dictStreetSquares);
                streetsquaresByColor[color].Add(this);

            } else {
                streetsquaresByColor[color].Add(this);
            }
        }
        
        public override void ReactToVisit(Player player) {
            Console.ForegroundColor = this.Color;
            Console.WriteLine($"You({player}: €{player.Money}) have arrived at {this.Name}");
            if(!this.Owned) {
                Console.WriteLine($"{this.Name} is not owned, want to buy this street for €{this.Rent}?");
                string userInput = Console.ReadLine();
                if(userInput.ToLower() == "yes" && player.Money >= this.Rent) {
                    player.BuyStreet(this);
                    this.Owned = true;
                    this.Owner = player;
                    player.Money -= this.Rent;
                } else if(player.Money < this.Rent) {
                    Console.WriteLine($"You have €{player.Money} left but this street costs €{this.Rent} to buy");
                }
            } else if((this.Owned && player.Equals(this.Owner))){ //build houses
                Console.WriteLine("You are the owner of this street");
                if(CheckAllOwnedStreets(player, this) == true) {
                    Console.WriteLine("You also own all the streets of the same color, would you like to build a house? (yes/no)");
                    string userInput = Console.ReadLine();
                    if(userInput.ToLower().Trim() == "yes") {
                        player.Money -= HouseCost;
                        this.totalHouses++;
                    }
                }

            } else {
                Console.WriteLine($"{this.Name} is owned by {this.Owner}, you must pay that player €{this.Rent}!");
                int transactionAmount = this.Rent;
                player.Money -= transactionAmount;
                this.Owner.Money += transactionAmount;
                Console.WriteLine($"You({player.Name}) paid rent to {this.Owner.Name} and now have €{player.Money}");
            }
            Console.ResetColor();

        }
        public override void ReactToTraversal(Player player) {
            //Passing by streets -> do nothing
        }
        private static bool CheckAllOwnedStreets(Player player, StreetSquare streetSquare) {
            byte counterStreets = 0;
            bool ownedAll = false;
            foreach(var street in StreetsquaresByColor[streetSquare.Color]) {
                if(street.Equals(streetSquare)) {
                    counterStreets++;
                }
            }
            if(counterStreets == StreetsquaresByColor[streetSquare.Color].Count) {
                ownedAll = true;
            }
            return ownedAll;
        }
    }
}