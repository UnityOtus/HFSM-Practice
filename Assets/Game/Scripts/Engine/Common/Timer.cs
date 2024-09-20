using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public class Timer
    {
        public float duration;
        public float time;

        public Timer(float duration)
        {
            this.duration = duration;
            this.time = duration;
        }

        public void Tick(float deltaTime)
        {
            this.time = Mathf.Max(0, this.time - deltaTime);
        }

        public void Reset()
        {
            this.time = this.duration;
        }

        public bool IsEnded()
        {
            return this.time <= 0;
        }
    }
}