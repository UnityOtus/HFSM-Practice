using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Atomic.AI
{
    [Serializable]
    public sealed class ThrottleBehaviour : IAIEnable, IAIDisable, IAIUpdate
    {
        [SerializeField]
        private float minScanPeriod = 0.2f;

        [SerializeField]
        private float maxScanPeriod = 0.3f;

        private float currentTime;

        [SerializeReference]
        private IAIUpdate behaviour = default;

        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (this.currentTime > 0)
            {
                this.currentTime -= deltaTime;
            }
            else
            {
                this.behaviour?.OnUpdate(blackboard, deltaTime);
                this.currentTime = Random.Range(this.minScanPeriod, this.maxScanPeriod);
            }
        }

        public void Disable(IBlackboard blackboard)
        {
            if (this.behaviour is IAIDisable behaviour)
            {
                behaviour.Disable(blackboard);
            }
        }

        public void Enable(IBlackboard blackboard)
        {
            if (this.behaviour is IAIEnable behaviour)
            {
                behaviour.Enable(blackboard);
            }
        }
    }
}