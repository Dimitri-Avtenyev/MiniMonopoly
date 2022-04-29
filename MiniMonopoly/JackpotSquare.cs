using System;

namespace MiniMonopoly
{
    class JackpotSquare : Square
    {
        private int jackpot;
        public int Jackpot {
            get {
                return this.jackpot;
            } set {
                this.jackpot = value;
            }
        }
        public JackpotSquare(string name):base(name) {

        }
        public override void ReactToVisit(Player player) {
            throw new NotImplementedException();
        }
        public override void ReactToTraversal(Player player) {
            throw new NotImplementedException();
        }
    }
}