using System.Collections.Generic;

namespace GameOfLife.Domain.Infrastructure
{
    public static class Pipeline<T>
    {
        public static T Execute(IEnumerable<IExecutor<T>> processes, T processItem)
        {
            if (processItem == null)
            {
                return default(T);
            }

            IExecutor<T> root = null;
            IExecutor<T> previous = null;

            foreach (IExecutor<T> rule in _GetRules(processes))
            {
                if (root == null)
                {
                    root = rule;
                }
                else
                {
                    previous.Register(rule);
                }
                previous = rule;
            }

            return root == null ? default(T) : root.Execute(processItem);
        }

        private static IEnumerable<IExecutor<T>> _GetRules(IEnumerable<IExecutor<T>> processes)
        {
            foreach (var process in processes)
            {
                yield return process;
            }
        }
    }
}
