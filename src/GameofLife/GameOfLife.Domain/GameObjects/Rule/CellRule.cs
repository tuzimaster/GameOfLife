using GameOfLife.Domain.GameObjects.Objects;

namespace GameOfLife.Domain.GameObjects.Rule
{
    public class CellRule : BasePipelineObject
    {
        private int[,] _surroundings = new int[3, 3];
        private Board _board;

        public bool Status;
        public int NumberOfNeighbors { get; set; }
        public bool IsAlive { get; set; }

        public void Initialize(Board board, int xPosition, int yPosition)
        {
            Status = false;
            _board = board;

            _surroundings = PopulateSurroundings(xPosition, yPosition);
            NumberOfNeighbors = GetNumberOfNeighbors();
            IsAlive = _surroundings[1, 1] == 1;
        }

        private int[,] PopulateSurroundings(int xPosition, int yPosition)
        {
            int[,] surroundings = new int[3, 3];

            for (int y = yPosition - 1; y < yPosition + 2; y++)
            {
                for (int x = xPosition - 1; x < xPosition + 2; x++)
                {
                    int xIndex = (x - xPosition) + 1;
                    int yIndex = (y - yPosition) + 1;

                    if (x >= 0 && y >= 0 && x < _board.Size && y < _board.Size)
                    {
                        surroundings[xIndex, yIndex] = _board.GameBoard[x, y];
                    }
                    else
                    {
                        surroundings[xIndex, yIndex] = 0;
                    }
                }
            }
            return surroundings;
        }

        private int GetNumberOfNeighbors()
        {
            int neighbors = 0;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (!(x == 1 && y == 1) && _surroundings[x,y] == 1)
                    {
                        neighbors++;
                    }
                }
            }

            return neighbors;
        }
    }
}
