using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class InMeleeRangeAICondition : IBlackboardCondition
    {
        [SerializeField] [BlackboardKey] private int _distanceKey; 
        public bool Invoke(IBlackboard blackboard)
        {
            GameObject character = blackboard.GetCharacter();
            GameObject target = blackboard.GetTarget();
            Vector2 currentPosition = character.transform.position;
            Vector2 targetPosition = target.transform.position;
            Vector2 distanceVector = targetPosition - currentPosition;
            float attackDistance = blackboard.GetFloat(_distanceKey);
            return (distanceVector.sqrMagnitude <= attackDistance * attackDistance);
        }
    }
}