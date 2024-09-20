using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class RangeAttackState : IState
    {
        public string Name => nameof(RangeAttackState);

        public void OnEnter(IBlackboard blackboard)
        {
            blackboard.GetCharacter().GetComponent<MoveComponent>().Stop();
        }

        public void OnExit(IBlackboard blackboard)
        {
            blackboard.GetCharacter().GetComponent<MoveComponent>().Stop();
        }

        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            GameObject character = blackboard.GetCharacter();

            if (!blackboard.TryGetTarget(out GameObject target) || target == null)
            {
                character.GetComponent<MoveComponent>().Stop();
                return;
            }

            if (!target.TryGetComponent(out HealthComponent healthComponent) || healthComponent.IsNotAlive())
            {
                character.GetComponent<MoveComponent>().Stop();
                return;
            }
            
            Vector2 currentPosition = character.transform.position;
            Vector2 targetPosition = target.transform.position;
            Vector2 distanceVector = targetPosition - currentPosition;
            
            float targetDirection = Mathf.Sign(distanceVector.x);
            
            character.GetComponent<LookComponent>().CurrentDirection = targetDirection;
            character.GetComponent<AttackComponent>().Attack();
        }
    }
}