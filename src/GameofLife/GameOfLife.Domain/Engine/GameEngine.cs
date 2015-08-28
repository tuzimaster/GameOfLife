using System;
using System.Linq;
using GameOfLife.Domain.GameObjects;
using GameOfLife.Domain.GameObjects.Objects;
using GameOfLife.Domain.GameObjects.Rule;
using GameOfLife.Domain.Infrastructure;

namespace GameOfLife.Domain.Engine
{
    public class GameEngine : IGameEngine
    {
        private Board _board;

        public GameEngine(Board board)
        {
            _board = board;
        }

        public void TakeTurn()
        {
            bool[,] results = GetRulePipelineResults();
            ApplyResults(results);
        }

        private void ApplyResults(bool[,] results)
        {
            for (int y = 0; y < _board.Size; y++)
            {
                for (int x = 0; x < _board.Size; x++)
                {
                    if (results[x, y])
                    {
                        _board.GameBoard[x, y] = 1;
                    }
                    else
                    {
                        _board.GameBoard[x, y] = 0;
                    }
                }
            }
        }

        private bool[,] GetRulePipelineResults()
        {
            bool[,] results = new bool[_board.Size, _board.Size];
            CellRule rule = new CellRule();
            rule.PipelineObject = rule.GetType();
            rule.PipelineObjectNamespaceName = true.GetType().FullName;
            var processes = new RuleFactory<IPipelineObject>().GetProcessors(rule).ToList();  //cast to avoid multiple enumerations

            for (int y = 0; y < _board.Size; y++)
            {
                for (int x = 0; x < _board.Size; x++)
                {
                    rule.Initialize(_board, x, y);
                    
                    var result = Pipeline<IPipelineObject>.Execute(processes, rule) as CellRule;

                    if (result == null)
                    {
                        throw new Exception("The pipeline being executed for cell rules must return a cell rule object.");
                    }

                    results[x, y] = result.Status;
                }
            }
            return results;
        }
    }
}
