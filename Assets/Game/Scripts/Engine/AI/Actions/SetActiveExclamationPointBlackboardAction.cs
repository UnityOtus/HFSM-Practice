// using System;
// using AIModule;
// using Modules.AI;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class SetActiveExclamationPointBlackboardAction : IBlackboardAction
//     {
//         [SerializeField]
//         private bool active;
//         
//         public void Invoke(IBlackboard blackboard)
//         {
//             blackboard.GetExclamationPoint().SetActive(this.active);
//         }
//     }
// }