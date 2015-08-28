using System;

namespace GameOfLife.Domain.GameObjects
{
    public abstract class BasePipelineObject : IPipelineObject
    {
        public Type PipelineObject { get; set; }
        public string PipelineObjectNamespaceName { get; set; }
    }
}
