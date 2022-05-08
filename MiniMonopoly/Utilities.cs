using System;
using System.Collections.Generic;

namespace MiniMonopoly 
{
    class Utilities 
    {
 
        public static bool AskYesOrNo(string question) {
            Console.WriteLine(question);
            string userInput = null;
            do {
                userInput = Console.ReadLine();
                if(userInput.ToLower() == "yes") {
                    return true;
                } else if (userInput.ToLower() == "no") {
                    return false;
                } else {
                    Console.WriteLine("Invalid input, please answer with 'yes' or 'no'");
                }
            } while(true);
        }
        public static Random RNG = new Random();
        public static void SlowPrintDots() {
            for(byte i=0; i<3;i++) {
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
            }
            Console.Write("\n");
        }
        public static void InsertRandomPlace(List<Square> board, LotterySquare card) {
            for(byte i = 0; i < 3; i++) {
                int insertIndex = Utilities.RNG.Next(1,board.Count); // 0 is for "GO" square
                board.Insert(insertIndex, card);
            }
        }
        public static void ShuffleCards() {

        }
    }
}