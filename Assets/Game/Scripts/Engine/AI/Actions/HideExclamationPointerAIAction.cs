using System;
using Atomic.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class HideExclamationPointerAIAction : IBlackboardAction
    {
        public void Invoke(IBlackboard blackboard)
        {
            blackboard.GetExclamationPointer().SetActive(false);
        }
    }
}