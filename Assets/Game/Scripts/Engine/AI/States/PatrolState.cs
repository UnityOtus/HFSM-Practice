using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    public sealed class PatrolState : IState
    {
        public string Name => nameof(PatrolState);
        
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
            Transform[] waypoints = blackboard.GetWaypoints();
            int waypointIndex = blackboard.GetWaypointIndex();
            float stoppingDistance = blackboard.GetStoppingDistance();

            Vector3 myPosition = character.transform.position;
            Vector3 targetPosition = waypoints[waypointIndex].position;
            Vector3 distanceVector = targetPosition - myPosition;

            bool waypointReached = distanceVector.sqrMagnitude <= stoppingDistance * stoppingDistance;
            if (waypointReached)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                blackboard.SetWaypointIndex(waypointIndex);
            }
            else
            {
                float direction = Mathf.Sign(distanceVector.x);
                character.GetComponent<MoveComponent>().CurrentDirection = direction;
            }
        }
    }
}