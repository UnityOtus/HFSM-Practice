// using System;
// using Modules.AI;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class SetActiveGameObjectBlackboardAction : IBlackboardAction
//     {
//         [SerializeField]
//         private bool active;
//
//         [BlackboardKey]
//         [SerializeField]
//         private int gameObjectKey;
//         
//         public void Invoke(IBlackboard blackboard)
//         {
//             blackboard.GetObject<GameObject>(gameObjectKey).SetActive(active);
//         }
//     }
// }