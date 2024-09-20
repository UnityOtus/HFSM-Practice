using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class TargetSelectReasoner : IAIUpdate
    {
        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (SelectClosestTarget(blackboard, out GameObject target))
            {
                blackboard.SetTarget(target);
            }
            else
            {
                blackboard.DelTarget();
            }
        }

        private static bool SelectClosestTarget(IBlackboard blackboard, out GameObject target)
        {
            target = null;

            ref var buffer = ref blackboard.GetColliderBuffer();
            int count = buffer.size;

            Vector3 myPosition = blackboard.GetCharacter().transform.position;

            float minDistance = float.MaxValue;

            Collider2D[] colliders = buffer.values;
            for (int i = 0; i < count; i++)
            {
                Collider2D other = colliders[i];

                if (!other.TryGetComponent(out HealthComponent healthComponent) || healthComponent.IsNotAlive())
                {
                    continue;
                }

                Vector3 targetPosition = other.transform.position;
                Vector3 distanceVector = targetPosition - myPosition;

                float targetDistance = distanceVector.sqrMagnitude;
                if (targetDistance < minDistance * minDistance)
                {
                    target = other.gameObject;
                    minDistance = targetDistance;
                }
            }

            return target != null;
        }
    }
}