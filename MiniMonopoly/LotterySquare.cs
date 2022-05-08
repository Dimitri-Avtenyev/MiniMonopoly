using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniMonopoly
{

    class LotterySquare : Square
    {
        public enum CardTypes {
            ChanceCard,
            CommunityCard
        }
        private List<string> chanceCardEffects = new List<string>(){
            ""
        };
        private List<string> communityCardEffects = new List<string>() {
            ""
        };
        private CardTypes cardType;
        public CardTypes CardType {
            get {
                return cardType;
            }
        }
        
        private static List<LotterySquare> lotterysquares = new List<LotterySquare>();
        public static ImmutableList<LotterySquare> LotterySquares {
            get {
                return lotterysquares.ToImmutableList();
            }
        }
        public LotterySquare(string name, CardTypes cardType):base(name) {
           this.cardType = cardType;
        }
        public override void ReactToVisit(Player player) {
            Console.WriteLine($"you landed on {this.Name}"); // placeholder for debug
            //switch -> effect of card no.X
        }
        public override void ReactToTraversal(Player player) {
            // Nothing happens when going OVER this square
        }
    }
}