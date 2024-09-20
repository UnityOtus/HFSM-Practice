// using System;
// using AIModule;
// using Atomic.Extensions;
// using Modules.AI;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class ResetCharacterMoveDirectionBlackboardAction : IBlackboardAction
//     {
//         public void Invoke(IBlackboard blackboard)
//         {
//             if (blackboard.TryGetCharacter(out var character))
//             {
//                 character.GetVariable<float>(MoveAPI.MoveDirection).Value = 0;
//             }
//         }
//     }
// }