// using System;
// using AIModule;
// using Atomic.Extensions;
// using Atomic.Objects;
// using Modules.AI;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class PatrolState : IState
//     {
//         public string Name => "Patrol State";
//
//         public void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             if (!blackboard.TryGetPatrolData(out IBlackboard.Ref<PatrolData> patrolData) ||
//                 !blackboard.TryGetCharacter(out IAtomicObject character) ||
//                 !blackboard.TryGetStoppingDistance(out float stoppingDistance))
//             {
//                 return;
//             }
//
//             if (!patrolData.value.enabled)
//             {
//                 return;
//             }
//
//             if (!character.TryGet(CommonAPI.Transform, out Transform transform))
//             {
//                 return;
//             }
//
//             Vector2 currentPosition = transform.position;
//             Vector2 targetPosition = patrolData.value.CurrentPosition;
//             Vector2 distanceVector = targetPosition - currentPosition;
//
//             if (distanceVector.sqrMagnitude <= stoppingDistance * stoppingDistance)
//             {
//                 patrolData.value.NextIndex();
//             }
//             else
//             {
//                 float moveDirection = Mathf.Sign(distanceVector.x);
//                 character.GetVariable<float>(MoveAPI.MoveDirection).Value = moveDirection;
//             }
//         }
//
//         public void OnEnter(IBlackboard blackboard)
//         {
//             if (blackboard.TryGetCharacter(out var character))
//             {
//                 character.GetVariable<float>(MoveAPI.MoveDirection).Value = 0;
//             }
//         }
//
//         public void OnExit(IBlackboard blackboard)
//         {
//             if (blackboard.TryGetCharacter(out var character))
//             {
//                 character.GetVariable<float>(MoveAPI.MoveDirection).Value = 0;
//             }
//         }
//     }
// }