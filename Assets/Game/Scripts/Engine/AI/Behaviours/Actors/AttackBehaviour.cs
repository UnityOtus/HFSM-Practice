// using System;
// using AIModule;
// using Atomic.Elements;
// using Atomic.Extensions;
// using Atomic.Objects;
// using Modules.AI;
// using UnityEngine;
// using UnityEngine.Scripting.APIUpdating;
//
// namespace Game.Engine.AI
// {
//     [MovedFrom(true, null, null, "AttackTargetBehaviour")] 
//     [Serializable]
//     public sealed class AttackBehaviour : IUpdateBehaviour
//     {
//         [BlackboardKey]
//         [SerializeField]
//         private int attackDataKey = BlackboardAPI.AttackData;
//         
//         public void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             if (!blackboard.TryGetStruct<AttackData>(this.attackDataKey, out var attackData) ||
//                 !blackboard.TryGetCharacter(out IAtomicObject character) ||
//                 !blackboard.TryGetTarget(out IAtomicObject target))
//             {
//                 return;
//             }
//
//             if (!attackData.value.enabled)
//             {
//                 return;
//             }
//
//             if (!target.TryGet(HealthAPI.IsAlive, out IAtomicValue<bool> isAlive) || !isAlive.Value)
//             {
//                 return;
//             }
//
//             if (!character.TryGet(CommonAPI.Transform, out Transform characterTransform) ||
//                 !target.TryGet(CommonAPI.Transform, out Transform targetTransform))
//             {
//                 return;
//             }
//
//             Vector2 currentPosition = characterTransform.position;
//             Vector2 targetPosition = targetTransform.position;
//             Vector2 distanceVector = targetPosition - currentPosition;
//
//             float targetDirection = Mathf.Sign(distanceVector.x);
//
//             if (distanceVector.sqrMagnitude <= attackData.value.MinDistanceSq)
//             {
//                 character.SetValue(CommonAPI.FlipDirection, targetDirection);
//                 character.InvokeAction(AttackAPI.AttackRequest);
//                 targetDirection = 0;
//             }
//
//             character.SetValue(MoveAPI.MoveDirection, targetDirection);
//         }
//     }
// }