// using System;
// using AIModule;
// using Modules.AI;
// using UnityEngine;
// using UnityEngine.Scripting.APIUpdating;
//
// namespace Game.Engine.AI
// {
//     [MovedFrom(true, null, null, "AttackOrPatrolBehaviour")] 
//     [Serializable]
//     public sealed class AttackOrPatrolReasoner : IUpdateBehaviour
//     {
//         public void OnUpdate(IBlackboard blackboard, float deltaTime)
//         {
//             bool targetExists = blackboard.HasTarget();
//             ref AttackData attackData = ref blackboard.GetAttackData();
//             ref PatrolData patrolData = ref blackboard.GetPatrolData();
//
//             attackData.enabled = targetExists;
//             patrolData.enabled = !targetExists;
//         }
//     }
// }