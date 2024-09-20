using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class Timer
    {
        [field: SerializeField]
        public float Duration { get; private set; }

        [field: SerializeField]
        public float RemainingTime { get; private set; }

        public Timer(float duration, float remainingTime)
        {
            this.Duration = duration;
            this.RemainingTime = remainingTime;
        }

        public void Tick(float deltaTime)
        {
            this.RemainingTime = Mathf.Max(0, this.RemainingTime - deltaTime);
        }

        public void Reset()
        {
            this.RemainingTime = this.Duration;
        }

        public bool IsEnded()
        {
            return this.RemainingTime <= 0;
        }
    }
}