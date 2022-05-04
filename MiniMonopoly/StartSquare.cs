using System;

namespace MiniMonopoly 
{
    class StartSquare : Square
    {
        public StartSquare(string name):base(name) {

        }
        public override void ReactToVisit(Player player) {
            Console.WriteLine($"{player.Name} is at 'GO' location");
        }
        public override void ReactToTraversal(Player player) {
            player.Money += 2000;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t>>> {player.Name} went by 'GO', received €2000 and has now €{player.Money}.<<<");
            Console.ResetColor();
        }
    }
}