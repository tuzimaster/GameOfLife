using System;

namespace GameOfLife.Domain.GameObjects.Objects
{
    public class Board
    {
        public int[,] GameBoard { get; set;}
        public int Size;

        public Board(int size)
        {
            GameBoard = new int[size,size];
            Size = size;
        }

        public void CreateBoard()
        {
            Console.WriteLine("\n\nDo you want to randomly generate the board, or enter it manually?");
            Console.WriteLine("Enter 'R' to randomly generate, otherwise you will need to manually enter the board.");

            string choice = Console.ReadLine();

            if (choice == "R")
            {
                GenerateRandomBoard(Size);
                return;
            }

            ManuallyEnteredBoard(Size);
        }

        private void ManuallyEnteredBoard(int size)
        {
            Console.WriteLine("\n\nValues for the board will be entered from the top left to the right");
            Console.WriteLine("The amount of rows will be the user provided size of the board entered.");
            Console.WriteLine("You must enter an integer 0 or 1 in order to move on to the next location.");
            Console.WriteLine("Remember, coordinates (0,0) start in the upper left hand corner.\n");

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    bool result = true;
                    while (result)
                    {
                        Console.WriteLine("Value for coordinate ({0},{1}) is:", x, y);
                        var input = Console.ReadLine();

                        int value;
                        if (int.TryParse(input, out value))
                        {
                            GameBoard[x, y] = value;
                            result = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!!!");
                        }
                    }
                }
            }
        }

        private void GenerateRandomBoard(int size)
        {
            //for easyness sack I'll be intializing this with random numbers for the first pass
            Random random = new Random();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    GameBoard[x, y] = random.Next(2);
                }
            }
        }

        public void PrintBoard()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    Console.Write(GameBoard[x, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}