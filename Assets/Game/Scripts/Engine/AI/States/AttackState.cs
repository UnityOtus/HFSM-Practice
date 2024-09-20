using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class AttackState : IState
    {
        public string Name => "Attack State";

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

            if (!blackboard.TryGetTarget(out GameObject target))
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
            float attackDistance = blackboard.GetAttackDistance();
            
            bool targetNotReached = distanceVector.sqrMagnitude > attackDistance * attackDistance;
            if (targetNotReached)
            {
                character.GetComponent<MoveComponent>().CurrentDirection = targetDirection;
            }
            else
            {
                character.GetComponent<MoveComponent>().Stop();
                character.GetComponent<LookComponent>().CurrentDirection = targetDirection;
                character.GetComponent<AttackComponent>().Attack();
            }
        }
    }
}