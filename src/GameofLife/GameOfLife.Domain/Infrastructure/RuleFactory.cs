using System.Collections.Generic;
using GameOfLife.Domain.GameObjects;
using GameOfLife.Domain.Rules.CellRules;

namespace GameOfLife.Domain.Infrastructure
{
    public class RuleFactory<T>
    {
        public IEnumerable<IExecutor<IPipelineObject>> GetProcessors(BasePipelineObject rule)
        {
            List<IExecutor<IPipelineObject>> processes = new List<IExecutor<IPipelineObject>>();

            if (rule.PipelineObject.FullName == "GameOfLife.Domain.GameObjects.Rule.CellRule")
            {
                processes.Add(new UnderPopulation());
                processes.Add(new Survival());
                processes.Add(new Overcrowding());
                processes.Add(new Reproduction());
            }

            return processes;
        }
    }
}
