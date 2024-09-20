// using System;
// using AIModule;
// using Modules.AI;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class PatrolDataInstaller : IBlackboardInstaller
//     {
//         [SerializeField]
//         private PatrolData patrolData;
//         
//         public void Install(IBlackboard blackboard)
//         {
//             blackboard.SetStruct(BlackboardAPI.PatrolData, this.patrolData);
//         }
//     }
// }