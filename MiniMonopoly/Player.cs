using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniMonopoly
{
    class Player
    {
        private string name;
        public string Name {
            get {
                return this.name;
            }
        }
        private int position;
        public int Position {
            get {
                return this.position;
            } set {
                this.position = value;
            }
        }
        private int money;
        public int Money {
            get {
                return this.money;
            } set {
                if(value < 0) {
                    Console.WriteLine("Money cannot be set negative.");
                } else {
                    this.money = value;
                }
            }
        }
        private List<StreetSquare> ownedProperties = new List<StreetSquare>();
        public ImmutableList<StreetSquare> OwnedProperties {
            get {
                return ownedProperties.ToImmutableList();
            }
        }
        public Player(string name) {
            this.name = name;
            this.Money = 1500; 
            this.Position = 0;
        }
        public void Act (List<Square> squares) {
            byte diceRoll = 0;
            diceRoll = this.RollDice();

            Console.WriteLine($"{this.Name} rolled {diceRoll}!");
            this.Position = (this.Position + (int)diceRoll)%(squares.Count); //position within squares limit
            squares[this.Position].ReactToTraversal(this);
            squares[this.Position].ReactToVisit(this);
        }
        public byte RollDice() {
            byte dice_1 = (byte)Utilities.RNG.Next(1,6+1);
            byte dice_2 = (byte)Utilities.RNG.Next(1,6+1);

            return (byte)(dice_1+dice_2);
        }
    }
}