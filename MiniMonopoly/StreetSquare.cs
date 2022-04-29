using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniMonopoly
{
    class StreetSquare : Square
    {
        private int rent;
        public int Rent {
            get {
                return this.rent;
            } set {
                if(value >= 0) {
                    this.rent = value;
                } else {
                    Console.WriteLine("Rent cannot be negative");
                }
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
            
        }
        public override void ReactToTraversal(Player player) {
            throw new NotImplementedException();
        }
    }
}