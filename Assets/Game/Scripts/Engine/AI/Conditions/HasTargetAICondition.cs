using System;
using Atomic.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class HasTargetAICondition : IBlackboardCondition
    {
        public bool Invoke(IBlackboard blackboard)
        {
            return blackboard.HasTarget();
        }
    }
}