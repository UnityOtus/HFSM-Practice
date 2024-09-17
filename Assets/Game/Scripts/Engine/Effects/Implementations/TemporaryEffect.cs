using System;
using Atomic.Behaviours;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public class TemporaryEffect : ICompletableEffect, IFixedUpdate
    {
        [SerializeField]
        private Countdown countdown;

        private Action<IEffect> callback;
        
        public virtual void Apply(AtomicBehaviour obj)
        {
            obj.AddLogic(this);
        }

        public virtual void Discard(AtomicBehaviour obj)
        {
            obj.RemoveLogic(this);
        }

        void ICompletableEffect.SetCallback(Action<IEffect> callback)
        {
            this.callback = callback;
        }

        void IFixedUpdate.OnFixedUpdate(float deltaTime)
        {
            this.countdown.Tick(deltaTime);

            if (this.countdown.time <= 0)
            {
                this.callback?.Invoke(this);
            }
        }
    }
}