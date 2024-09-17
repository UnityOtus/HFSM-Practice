using Atomic.Behaviours;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    public abstract class ScriptableEffect : ScriptableObject, IEffect
    {
        public abstract void Apply(AtomicBehaviour obj);

        public abstract void Discard(AtomicBehaviour obj);
    }
}