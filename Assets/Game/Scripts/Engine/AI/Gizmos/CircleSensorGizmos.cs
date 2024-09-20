// using System;
// using AIModule;
// using Modules.AI;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class CircleSensorGizmos : IDrawGizmos
//     {
//         
//         [SerializeField]
//         private Color color = Color.magenta;
//         
//         public void OnGizmos(IBlackboard blackboard)
//         {
//             CircleSensorData data = blackboard.GetCircleSensorData();
//
//             Color prevColor = Gizmos.color;
//             Gizmos.color = this.color;
//             Gizmos.DrawWireSphere(data.center.position, data.radius);
//             Gizmos.color = prevColor;
//         }
//     }
// }