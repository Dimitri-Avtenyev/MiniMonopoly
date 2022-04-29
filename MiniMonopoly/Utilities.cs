using System;

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
    }
}