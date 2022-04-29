using System;

namespace MiniMonopoly
{
    class GambleSquare : Square
    {
        public GambleSquare(string name, JackpotSquare jackpotSquare):base(name) {

        }
        public override void ReactToVisit(Player player) {
            throw new NotImplementedException();
        }
        public override void ReactToTraversal(Player player) {
            throw new NotImplementedException();
        }
    }
}