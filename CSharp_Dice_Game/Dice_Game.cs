
using System.Reflection.Metadata;
using System.Runtime;

internal class Dice_Game
 {
    // Fields
    private static Random random = new Random();
    
    // Int Fields
    private static int rollAmount;
    private static int diceOneScore;
    private static int diceTwoScore;
    private static int totalAmount;
    private const int minValue = 1;
    private const int maxValue = 7; 

    // String Fields
    private static string userInput;
    private const string RollPrompt = "Would you like to roll the dice?";

    


    static void Main(string[] args)
    {
        Console.Title = "Dice Game";
        Console.WriteLine("Created by Avro_Arrow\n");
        Console.WriteLine();
       

        // Starting of the Game, basically the Main Menu
        Start:
            while (true)
            {
                // Asks user if they would like to play
                Console.Write($"\n{RollPrompt}: (Y/N): ");
                userInput = Console.ReadLine().ToUpper();

                if (userInput.ToUpper() == "Y")
                {
                    // Will ask the user how many times they would like to roll the dice.
                    GetRollCount(out rollAmount);

                    // Starts the game once everything has been filled in.
                    Console.WriteLine("\nEnjoy the game!\n");
                    break;
                }

                // If the user selects "No" in the start, then it will end the application.
                else if (userInput.ToUpper() == "N")
                {

                    Console.WriteLine("Exiting game...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);

                }

                // If the player, when prompted at the beginning to either picl "Yes" or "No", inserts an invalid option, will loop back.
                Console.WriteLine("Please insert a proper option\n");

            }

        // Gameplay
        while( rollAmount > 0)
        {
            StartOfTheGamePlay:
                Console.Write($"{RollPrompt}, you have {rollAmount} rolls left (Y/N): ");
                userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    // Will roll the dice if the player selects "Yes"
                    case "Y":
                        diceOneScore = RollDie();
                        diceTwoScore = RollDie();
                        totalAmount += diceOneScore + diceTwoScore;
                        rollAmount--;

                        Console.WriteLine("\nRolling the 1st Die....");
                        Console.WriteLine($"The 1st Die rolled {diceOneScore}");

                        Thread.Sleep(1000);
                        Console.WriteLine("Rolling the 2st Die....");
                        Console.WriteLine($"The 2nd Die rolled: {diceTwoScore}\n");

                        Console.WriteLine($"The total for this round: is: {diceOneScore + diceTwoScore}");
                        break;

                    // Will bring the player back to the beginning if they select "No"
                    case "N":
                        Console.WriteLine("Going to the beginning...");
                        Thread.Sleep(2000);
                        goto Start;

                    // Will stop the user from inputing an invalid character/option.
                    default:
                        Console.WriteLine("Unsupported character... Please insert a valid character.\n");
                        goto StartOfTheGamePlay;
                }
        }

    // Optional Restart
    StartOfOptionalRestart:
        Console.WriteLine($"\nThe grand total is: {totalAmount}");
        Console.Write($"Would you like to play again? (Y/N): ");
        userInput = Console.ReadLine().ToUpper();

        switch (userInput)
        {
            case "Y":
                rollAmount = 3;
                diceOneScore = 0;
                diceTwoScore = 0;
                totalAmount = 0;

                goto Start;

            case "N":
                Console.WriteLine("\nExiting Game....");
                Thread.Sleep(1000);
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Unsupported character... Please insert a valid character.\n");
                goto StartOfOptionalRestart;

        }
    }
       

    // Will roll die #1
    private static int RollDie() 
    {
        return random.Next(minValue, maxValue);
    }

    private static void GetRollCount(out int rollAmount){
        while (true){
            Console.Write($"Please enter a Roll Amount (Numerical): ");
            if (int.TryParse(Console.ReadLine(), out int rollCount) && rollCount > 0)
            {
                rollAmount = rollCount;
                break;
            }
            else
            {
                Console.WriteLine("Please insert a numerical value greater than 0... Try again.\n");
            }
        }
    }

}
