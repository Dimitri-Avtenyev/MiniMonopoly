using System;

namespace MiniMonopoly 
{
    class StartSquare : Square
    {
        private int goValue = 200; //default
        public int GoValue {
            get {
                return this.goValue;
            } private set {
                goValue = value;
            }
        }
        public StartSquare(string name):base(name) {

        }
        public override void ReactToVisit(Player player) {
            Console.WriteLine($"{player.Name} is at 'GO' location");
        }
        public override void ReactToTraversal(Player player) {
            player.Money += this.goValue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t>>> {player.Name} went by 'GO', received €{this.GoValue} and has now €{player.Money}.<<<");
            Console.ResetColor();
        }
    }
}