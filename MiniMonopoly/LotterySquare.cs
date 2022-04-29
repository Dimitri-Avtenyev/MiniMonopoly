using System;

namespace MiniMonopoly
{
    class LotterySquare : Square
    {
        public LotterySquare(string name):base(name) {
            
        }
        public override void ReactToVisit(Player player) {
            throw new NotImplementedException();
        }
        public override void ReactToTraversal(Player player) {
            throw new NotImplementedException();
        }
    }
}