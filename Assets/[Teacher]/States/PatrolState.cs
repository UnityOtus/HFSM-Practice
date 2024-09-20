// using System;
// using Atomic.AI;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class PatrolState : IState
//     {
//         public string Name => "Patrol State";
//
//         public void OnEnter(IBlackboard blackboard)
//         {
//             blackboard.GetCharacter().GetComponent<MoveComponent>().Stop();
//         }
//
//         public void OnExit(IBlackboard blackboard)
//         {
//             blackboard.GetCharacter().GetComponent<MoveComponent>().Stop();
//         }
//
//         public void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             GameObject character = blackboard.GetCharacter();
//             float stoppingDistance = blackboard.GetStoppingDistance();
//             
//             Transform[] waypoints = blackboard.GetWaypoints();
//             int waypointIndex = blackboard.GetWaypointIndex();
//             
//             
//             Vector2 currentPosition = character.transform.position;
//             Vector2 targetPosition = waypoints[waypointIndex].position;
//             Vector2 distanceVector = targetPosition - currentPosition;
//
//             if (distanceVector.sqrMagnitude <= stoppingDistance * stoppingDistance)
//             {
//                 waypointIndex = (waypointIndex + 1) % waypoints.Length;
//                 blackboard.SetWaypointIndex(waypointIndex);
//             }
//             else
//             {
//                 float moveDirection = Mathf.Sign(distanceVector.x);
//                 character.GetComponent<MoveComponent>().CurrentDirection = moveDirection;
//             }
//         }
//     }
// }