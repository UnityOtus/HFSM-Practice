using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class SensorDataInstaller : IBlackboardInstaller
    {
        [SerializeField]
        private SensorData sensorData;
        
        public void Install(IBlackboard blackboard)
        {
            blackboard.SetSensorData(this.sensorData);
        }
    }
}