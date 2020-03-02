using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreTracker
{
    class Program
    {  
        static void Main(string[] args)
        {
            while (true)
            {
                string player1Name = "";
                string player2Name = "";
                string player1Score = "";
                string player2Score = "";
                ScoreService scoreService = new ScoreService();

                Console.WriteLine("Enter player 1 name: ");
                player1Name = Console.ReadLine();
                while (string.IsNullOrEmpty(player1Name))
                {
                    Console.WriteLine("You must enter a name!");
                    player1Name = Console.ReadLine();
                }

                Console.WriteLine("Enter player 1 score: ");
                player1Score = Console.ReadLine().ToUpper();
                while (!scoreService.IsValidScore(player1Score))
                {
                    Console.WriteLine("You must enter a valid score valid options are 0, 15, 30, 40, and A");
                    player1Score = Console.ReadLine().ToUpper();
                }

                Console.WriteLine("Enter player 2 name: ");
                player2Name = Console.ReadLine();
                while (string.IsNullOrEmpty(player2Name))
                {
                    Console.WriteLine("You must enter a name!");
                    player2Name = Console.ReadLine();
                }

                Console.WriteLine("Enter player 2 score: ");
                player2Score = Console.ReadLine().ToUpper();
                while (!scoreService.IsValidScore(player2Score, player1Score))
                {
                    Console.WriteLine("You must enter a valid score valid options are 0, 15, 30, 40, and A");
                    player2Score = Console.ReadLine().ToUpper();
                }

                Console.WriteLine($"Enter the number 0 if {player1Name} scored a point.");
                Console.WriteLine($"Or Enter the number 1 if {player2Name} scored a point.");
                ActionType action;
                string strAction = Console.ReadLine();
                while (!Enum.TryParse(strAction, out action))
                {
                    Console.WriteLine("Your input was not valid:");
                    Console.WriteLine($"Enter the number 0 if {player1Name} scored a point.");
                    Console.WriteLine($"Or Enter the number 1 if {player2Name} scored a point.");
                    strAction = Console.ReadLine();
                }

                try
                {
                    ScoreboardModel currentScore = new ScoreboardModel(player1Name, player2Name, player1Score, player2Score);
                    scoreService.GetScoreByAction(currentScore, action);
                    Console.WriteLine(scoreService.GetScoreString(currentScore));
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }                  
        }      
    }
}
