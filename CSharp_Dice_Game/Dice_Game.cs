
using System.Reflection.Metadata;
using System.Runtime;

internal class Dice_Game
 {
    // Fields
    private static int rollAmount = 3;
    private static int diceOneScore;
    private static int diceTwoScore;
    private static int totalAmount;
    private static string userInput;


    static void Main(string[] args)
    {
        Console.Title = "Dice Game";
        Console.WriteLine("Created by Avro_Arrow\n");
        Console.WriteLine();
       

        // Starting of the Game, basically the Main Menu
        Start:
            while (true)
            {
                


                Console.Write("Would you like to play the Dice Game: (Y/N): ");
                userInput = Console.ReadLine().ToUpper();

                if (userInput.ToUpper() == "Y")
                {
                    Console.WriteLine("Enjoy the game!\n");
                    break;
                }

                else if (userInput.ToUpper() == "N")
                {

                    Console.WriteLine("Exiting game...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);

                }

                Console.WriteLine("Please insert a proper option\n");

            }

        // Gameplay
        while( rollAmount > 0)
        {
            StartOfTheGamePlay:
                Console.Write($"Would you like to roll the dice, you have {rollAmount} rolls left (Y/N): ");
                userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "Y":
                        diceOneScore = RollDiceOne();
                        diceTwoScore = RollDiceTwo();
                        totalAmount += diceOneScore + diceTwoScore;
                        rollAmount--;

                        Console.WriteLine("Rolling the 1st Die....");
                        Console.WriteLine($"The 1st Die rolled {diceOneScore}");

                        Thread.Sleep(1000);
                        Console.WriteLine("Rolling the 2st Die....");
                        Console.WriteLine($"The 1st Die rolled {diceTwoScore}\n");

                        Console.WriteLine($"The total for this round is: {diceOneScore + diceTwoScore}");
                        break;

                    case "N":
                        Console.WriteLine("Going to the beginning...");
                        Thread.Sleep(2000);
                        goto Start;

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
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Unsupported character... Please insert a valid character.\n");
                goto StartOfOptionalRestart;

        }
    }
       


    private static int RollDiceOne() 
    {
        Random random = new Random();
        int minValue = 1;
        int maxValue = 6; 
        int randomNumber = random.Next(minValue, maxValue);

        return randomNumber;
        

    }

    private static int RollDiceTwo()
    {
        Random random = new Random();
        int minValue = 1;
        int maxValue = 6;
        int randomNumber = random.Next(minValue, maxValue);

        return randomNumber;
    }

    //private static int FinalScoreSystem()
   // {
     //   Console
    //        .WriteLine("The dice")
   // }
}
