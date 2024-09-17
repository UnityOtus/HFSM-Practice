using System;
using AIModule;
using Modules.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class CircleSensorDataInstaller : IBlackboardInstaller
    {
        [SerializeField]
        private CircleSensorData sensorData;
        
        public void Install(IBlackboard blackboard)
        {
            blackboard.SetCircleSensorData(this.sensorData);
        }
    }
}