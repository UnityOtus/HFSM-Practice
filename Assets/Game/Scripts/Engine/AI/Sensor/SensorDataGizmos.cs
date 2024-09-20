using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class SensorDataGizmos : IAIGizmos
    {
        [SerializeField]
        private Color color = Color.magenta;
        
        public void OnGizmos(IBlackboard blackboard)
        {
            ref SensorData data = ref blackboard.GetSensorData();

            Color prevColor = Gizmos.color;
            Gizmos.color = this.color;
            Gizmos.DrawWireSphere(data.center.position, data.radius);
            Gizmos.color = prevColor;
        }
    }
}