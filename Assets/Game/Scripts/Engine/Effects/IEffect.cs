using System;
using Atomic.Behaviours;

namespace Game.Engine
{
    public interface IEffect
    {
        void Apply(AtomicBehaviour obj);
        
        void Discard(AtomicBehaviour obj);
    }

    public interface ICompletableEffect : IEffect
    {
        protected internal void SetCallback(Action<IEffect> callback);
    }
}