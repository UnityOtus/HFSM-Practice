using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class ColliderSensor : IAIUpdate
    {
        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            ref SensorData sensorData = ref blackboard.GetSensorData();
            ref BufferData<Collider2D> buffer = ref blackboard.GetColliderBuffer();

            int size = Physics2D.OverlapCircleNonAlloc(
                sensorData.center.position,
                sensorData.radius,
                buffer.values,
                sensorData.layerMask
            );
            
            buffer.size = size;
        }
    }
}