using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class IsTargetInMeleeRange : IBlackboardCondition
    {
        public bool Invoke(IBlackboard blackboard)
        {
            var target = blackboard.GetTarget();
            var character = blackboard.GetCharacter();

            float dist = Vector3.Distance(target.transform.position, character.transform.position);
            return dist <= blackboard.GetMeleeAttackDistance();
        }
    }
}