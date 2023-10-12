using System;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;
        static bool playAgainstComputer = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Choose number of players (1 or 2):");
            int numPlayers;
            while (!int.TryParse(Console.ReadLine(), out numPlayers) || (numPlayers != 1 && numPlayers != 2))
            {
                Console.WriteLine("Invalid input. Choose 1 to play against the computer or 2 for two players.");
            }

            if (numPlayers == 1)
            {
                playAgainstComputer = true;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine(playAgainstComputer ? "Computer's turn" : "Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }
                Console.WriteLine("\n");
                Board();

                if (player % 2 == 0 && playAgainstComputer)
                {
                    Random rnd = new Random();
                    choice = rnd.Next(1, 10);

                    while (arr[choice] == 'X' || arr[choice] == 'O')
                    {
                        choice = rnd.Next(1, 10);
                    }
                }
                else
                {
                    bool validInput = false;
                    while (true)
                    {
                        string input = Console.ReadLine();
                        validInput = Int32.TryParse(input, out choice);
                        if (validInput)
                        {
                            if (choice < 1 || choice > 9 || arr[choice] == 'X' || arr[choice] == 'O')
                            {
                                Console.WriteLine("Please enter a valid empty cell number");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid number");
                        }
                    }
                }

                if (player % 2 == 0)
                {
                    arr[choice] = 'O';
                    player++;
                }
                else
                {
                    arr[choice] = 'X';
                    player++;
                }
                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Board();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.ReadLine();
        }

        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin()
        {
            #region Horzontal Winning Conditions
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Vertical Winning Conditions
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Conditions
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
    }
}
