using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class ShowExclamationViewAIAction : IBlackboardAction
    {
        [SerializeField]
        private bool show;
        
        public void Invoke(IBlackboard blackboard)
        {
            blackboard.GetExclamationView().SetActive(this.show);
        }
    }
}