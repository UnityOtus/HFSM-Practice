// using System;
// using AIModule;
// using Modules.AI;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class CircleCollider2DSensor : IUpdateBehaviour
//     {
//         public void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             ref CircleSensorData sensorData = ref blackboard.GetCircleSensorData();
//             ref BufferData<Collider2D> buffer = ref blackboard.GetCollidersBuffer();
//
//             int size = Physics2D.OverlapCircleNonAlloc(
//                 sensorData.center.position,
//                 sensorData.radius,
//                 buffer.values,
//                 sensorData.layerMask
//             );
//             
//             buffer.size = size;
//         }
//     }
// }