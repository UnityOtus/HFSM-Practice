using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class TargetDistanceReachedAICondition : IBlackboardCondition
    {
        [SerializeField, BlackboardKey]
        private int distanceKey;
        
        public bool Invoke(IBlackboard blackboard)
        {
            Vector3 characterPosition = blackboard.GetCharacter().transform.position;
            Vector3 targetPosition = blackboard.GetTarget().transform.position;
            Vector3 distanceVector = targetPosition - characterPosition;
            
            float stoppingDistance = blackboard.GetFloat(this.distanceKey);
            return distanceVector.sqrMagnitude <= stoppingDistance * stoppingDistance;
        }
    }
}