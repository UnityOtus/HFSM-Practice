using System;
using AIModule;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Modules.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class AttackState : IState
    {
        public string Name => this.name;

        [SerializeField]
        private string name = "Attack State";

        [BlackboardKey]
        [SerializeField]
        private int attackDataKey = BlackboardAPI.AttackData;

        public void OnEnter(IBlackboard blackboard)
        {
            if (blackboard.TryGetCharacter(out var character))
            {
                character.GetVariable<float>(MoveAPI.MoveDirection).Value = 0;
            }
        }

        public void OnExit(IBlackboard blackboard)
        {
            Stop(blackboard);
        }

        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (!blackboard.TryGetStruct<AttackData>(this.attackDataKey, out var attackData) ||
                !blackboard.TryGetCharacter(out IAtomicObject character) ||
                !blackboard.TryGetTarget(out IAtomicObject target))
            {
                Stop(blackboard);
                return;
            }

            if (!attackData.value.enabled)
            {
                Stop(blackboard);
                return;
            }

            if (!target.TryGet(HealthAPI.IsAlive, out IAtomicValue<bool> isAlive) || !isAlive.Value)
            {
                Stop(blackboard);
                return;
            }

            if (!character.TryGet(CommonAPI.Transform, out Transform characterTransform) ||
                !target.TryGet(CommonAPI.Transform, out Transform targetTransform))
            {
                Stop(blackboard);
                return;
            }

            Vector2 currentPosition = characterTransform.position;
            Vector2 targetPosition = targetTransform.position;
            Vector2 distanceVector = targetPosition - currentPosition;

            float targetDirection = Mathf.Sign(distanceVector.x);

            if (distanceVector.sqrMagnitude <= attackData.value.MinDistanceSq)
            {
                character.SetValue(CommonAPI.FlipDirection, targetDirection);
                character.InvokeAction(AttackAPI.AttackRequest);
                targetDirection = 0;
            }

            character.SetValue(MoveAPI.MoveDirection, targetDirection);
        }
        
        private static void Stop(IBlackboard blackboard)
        {
            if (blackboard.TryGetCharacter(out var character))
            {
                character.GetVariable<float>(MoveAPI.MoveDirection).Value = 0;
            }
        }
    }
}