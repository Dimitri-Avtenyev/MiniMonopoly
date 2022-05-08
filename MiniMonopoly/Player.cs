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
                    Console.WriteLine("You are bankrupt :(");
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
            byte diceRoll = this.RollDice();
            int beginPosition = this.Position;
            int endPosition = 0;// (this.Position + diceRoll)%(squares.Count);//position within suares limit

            Console.WriteLine($"{this.Name} rolled {diceRoll}!");
           
            for(byte i = 1; i<= diceRoll; i++) { //react to every NEXT step on square -> start i = 1 
                endPosition = (beginPosition + i)%squares.Count;
                squares[endPosition].ReactToTraversal(this);
            }
            this.Position = endPosition;
            squares[this.Position].ReactToVisit(this);
        }
        public byte RollDice() {
            byte dice1 = (byte)Utilities.RNG.Next(1,6+1);
            byte dice2 = (byte)Utilities.RNG.Next(1,6+1);

            return (byte)(dice1+dice2);
        }
        public override string ToString() {
            return $"{this.Name}";
        }
        public void BuyStreet(StreetSquare street) {
            ownedProperties.Add(street);
        }
    }
   
}