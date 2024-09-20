using System;
using Atomic.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class ShowExclamationPointerAIAction : IBlackboardAction
    {
        public void Invoke(IBlackboard blackboard)
        {
            blackboard.GetExclamationPointer().SetActive(true);
        }
    }
}