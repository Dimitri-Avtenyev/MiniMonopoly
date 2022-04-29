using System;

namespace MiniMonopoly
{
    abstract class Square
    {
        private string name;
        public string Name {
            get {
                return this.name;
            }
        }
        public Square(string name) {
            this.name = name;
        }
        public abstract void ReactToVisit(Player player);
        public abstract void ReactToTraversal(Player player);
    }
}