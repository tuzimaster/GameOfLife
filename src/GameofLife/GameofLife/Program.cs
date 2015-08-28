using System;
using GameOfLife.Domain.Engine;
using GameOfLife.Domain.GameObjects.Objects;

namespace GameofLife
{
    class Program
    {
        static void Main()
        {
            int? size = GetBoardSize();

            if (!size.HasValue)
            {
                Console.WriteLine("Provided value is not an integer.  Exiting.");
                return;
            }

            Board board = new Board(size.Value);

            board.CreateBoard();

            Console.WriteLine("The board entered:");
            board.PrintBoard();
            
            IGameEngine engine = new GameEngine(board);
            while (true)
            {
                Console.WriteLine("To play a turn, simply press any key other than N.  To quit, press 'N'.");
                string input = Console.ReadLine();

                if (input == "N")
                {
                    break;
                }

                engine.TakeTurn();

                Console.WriteLine("\nBoard result:");
                board.PrintBoard();
            }
            
            Console.ReadLine();
        }
        
        private static int? GetBoardSize()
        {
            Console.WriteLine("Enter the board size as an integer (1,2,3,etc).");
            string input = Console.ReadLine();
            int size;
            if (!int.TryParse(input, out size))
            {
                return null;
            }
            return size;
        }
    }
}
