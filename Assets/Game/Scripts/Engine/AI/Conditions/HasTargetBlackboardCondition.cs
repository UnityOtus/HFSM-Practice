using System;
using AIModule;
using Modules.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class HasTargetBlackboardCondition : IBlackboardCondition
    {
        public bool Invoke(IBlackboard blackboard)
        {
            return blackboard.HasTarget();
        }
    }
}