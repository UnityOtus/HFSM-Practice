using System;
using AIModule;
using Modules.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class ExclamationPointInstaller : IBlackboardInstaller
    {
        [SerializeField]
        private GameObject exclamationPoint;
        
        public void Install(IBlackboard blackboard)
        {
            blackboard.SetExclamationPoint(this.exclamationPoint);
        }
    }
}