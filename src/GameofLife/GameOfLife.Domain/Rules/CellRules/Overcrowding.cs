using System;
using GameOfLife.Domain.GameObjects;
using GameOfLife.Domain.GameObjects.Rule;
using GameOfLife.Domain.Infrastructure;

namespace GameOfLife.Domain.Rules.CellRules
{
    public class Overcrowding : BaseExecutor<IPipelineObject>
    {
        protected override IPipelineObject _Execute(IPipelineObject input)
        {
            var cellRule = input as CellRule;

            if (cellRule == null)
            {
                throw new ArgumentException("Input provided is not a CellRule object.");
            }

            if (cellRule.IsAlive && cellRule.NumberOfNeighbors > 3)
            {
                cellRule.Status = false;
            }

            return cellRule;
        }
    }
}
