// using System;
// using AIModule;
// using Atomic.Elements;
// using Atomic.Objects;
// using Modules.AI;
// using UnityEngine;
// using UnityEngine.Scripting.APIUpdating;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class TargetSelectReasoner : IUpdateBehaviour
//     {
//         public void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             if (SelectClosestTarget(blackboard, out IAtomicObject target))
//             {
//                 blackboard.SetTarget(target);
//             }
//             else
//             {
//                 blackboard.DelTarget();
//             }
//         }
//
//         private static bool SelectClosestTarget(IBlackboard blackboard, out IAtomicObject target)
//         {
//             target = null;
//
//             ref var buffer = ref blackboard.GetCollidersBuffer();
//             int count = buffer.size;
//             
//             Collider2D[] colliders = buffer.values;
//
//             Vector3 characterPosition = blackboard
//                 .GetCharacter()
//                 .Get<Transform>(CommonAPI.Transform)
//                 .position;
//
//             float minDistance = float.MaxValue;
//
//             for (int i = 0; i < count; i++)
//             {
//                 Collider2D collider = colliders[i];
//                 if (!collider.TryGetComponent(out IAtomicObject obj))
//                 {
//                     continue;
//                 }
//
//                 if (!obj.TryGet(HealthAPI.IsAlive, out IAtomicValue<bool> isAlive) ||
//                     !isAlive.Value)
//                 {
//                     continue;
//                 }
//
//                 Vector3 targetPosition = obj
//                     .Get<Transform>(CommonAPI.Transform)
//                     .position;
//
//                 Vector3 distanceVector = targetPosition - characterPosition;
//                 float targetDistance = distanceVector.sqrMagnitude;
//
//                 if (targetDistance < minDistance * minDistance)
//                 {
//                     target = obj;
//                     minDistance = targetDistance;
//                 }
//             }
//
//             return target != null;
//         }
//     }
// }