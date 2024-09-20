// using System;
// using AIModule;
// using Atomic.Objects;
// using Modules.AI;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public sealed class AttackDistanceBlackboardCondition : IBlackboardCondition
//     {
//         private enum ComparisonType
//         {
//             LESS = 0,
//             LESS_OR_EQUALS = 1,
//             MORE = 2,
//             MORE_OR_EQUALS = 3
//         }
//         
//         [SerializeField, BlackboardKey]
//         private int attackDataKey;
//
//         [SerializeField]
//         [FormerlySerializedAs("equationType")]
//         private ComparisonType comparisonType;
//
//         public bool Invoke(IBlackboard blackboard)
//         {
//             if (!blackboard.TryGetCharacter(out IAtomicObject character) |
//                 !blackboard.TryGetTarget(out IAtomicObject target) |
//                 !blackboard.TryGetStruct<AttackData>(this.attackDataKey, out var attackData))
//             {
//                 return false;
//             }
//
//             if (!character.TryGet(CommonAPI.Transform, out Transform characterTransform) ||
//                 !target.TryGet(CommonAPI.Transform, out Transform targetTransform))
//             {
//                 return false;
//             }
//
//             Vector2 distance = characterTransform.position - targetTransform.position;
//
//             float currentDistance = distance.sqrMagnitude;
//             float targetDistance = attackData.value.MinDistanceSq;
//
//             return this.comparisonType switch
//             {
//                 ComparisonType.LESS => currentDistance < targetDistance,
//                 ComparisonType.LESS_OR_EQUALS => currentDistance <= targetDistance,
//                 ComparisonType.MORE => currentDistance > targetDistance,
//                 ComparisonType.MORE_OR_EQUALS => currentDistance >= targetDistance,
//                 _ => throw new Exception($"Equation of type {comparisonType} is not found!")
//             };
//         }
//     }
// }