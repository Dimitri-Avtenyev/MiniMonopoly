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
        //could be better with class Card and its effects, now it's hardcoded just for demo
        private List<string> chanceCardEffects = new List<string>(){
            "You had high hopes but this card has zero value, here's a smiley though :)",
            "Your crypto went up in value, you cashed and gained €200",
            "Username length price went up, pay €5/letter of your username"
        };
        private List<string> communityCardEffects = new List<string>() {
            "You forgot to pay for all your streaming subscriptions, cost you €50",
            "You HAD to buy all the DLCs for your main game, cost you €250",
            "Your steam refund went through and you receive €60"
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
            Console.WriteLine($"you landed on {this.Name}, your card is being selected.\n");
            Utilities.SlowPrintDots();
            int randomIndex = 0;
            if(this.CardType == CardTypes.ChanceCard) {
                randomIndex =  Utilities.RNG.Next(0,chanceCardEffects.Count);
                Console.WriteLine(chanceCardEffects[randomIndex]);
                switch(randomIndex) {
                    case(0): 
                        // 0 doesn't do anything
                        break;
                    case(1): 
                        player.Money+=200;
                        break;
                    case(2): 
                        player.Money -= (5*player.Name.Length);
                        break;
                }
            } else if (this.CardType == CardTypes.CommunityCard) {
                randomIndex =  Utilities.RNG.Next(0,communityCardEffects.Count);
                Console.WriteLine(communityCardEffects[randomIndex]);
                switch(randomIndex) {
                    case(0): 
                        player.Money -= 50;
                        break;
                    case(1): 
                        player.Money -= 250;
                        break;
                    case(2): 
                        player.Money += 60;
                        break;
                }
            }
        }
        public override void ReactToTraversal(Player player) {
            // Nothing happens when going OVER this square
        }
    }
}