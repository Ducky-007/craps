// creates the game Craps

using System;

class Craps
{
    private static Random randomNums = new Random(); // creates random num generator

    private enum Status { Continue, Won, Lost } // enums over constants that rep game status

    private enum DiceNames // enums over constants repping common dice rolls 
    {
        SnakeEyes = 2,
        Trey = 3,
        Seven = 7,
        YoLeven = 11,
        BoxCars = 12
    }

    // plays one game of craps
    static void Main()
    {
        Status gameStatus = Status.Continue;
        int myPoint = 0;

        int sumOfDice = RollDice();

        // switch between dice names depending on sum of dice
        switch ((DiceNames) sumOfDice)
        {
            case DiceNames.Seven:
            case DiceNames.YoLeven:
                gameStatus = Status.Won;
                break;
            case DiceNames.SnakeEyes:
            case DiceNames.Trey:
            case DiceNames.BoxCars:
                gameStatus = Status.Lost;
                break;
            default:
                gameStatus = Status.Continue;
                myPoint = sumOfDice;
                Console.WriteLine($"Point is {myPoint}\n");
                break;
        }

        while (gameStatus == Status.Continue)
        {
            sumOfDice = RollDice();

            if (sumOfDice == myPoint)
            {
                gameStatus = Status.Won;
            }
            else
            {
                if (sumOfDice == (int)DiceNames.Seven)
                {
                    gameStatus = Status.Lost;
                }
            }
        }

        if (gameStatus == Status.Won)
        {
            Console.WriteLine("Palyer wins!");
        }
        else
        {
            Console.WriteLine("Player loses!");
        }

        static int RollDice()
        {
            int die1 = randomNums.Next(1, 7);
            int die2 = randomNums.Next(1, 7);
            int sum = die1 + die2;

            Console.WriteLine($"Player rolled {die1} + {die2} = {sum}");
            return sum;
        }
    }
}