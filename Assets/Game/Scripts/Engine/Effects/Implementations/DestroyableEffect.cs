using System;
using Atomic.Behaviours;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class DestroyableEffect : IEffect
    {
        [SerializeField]
        private GameObject gameObject;
        
        public void Apply(AtomicBehaviour obj)
        {
            //Nothing...
        }

        public void Discard(AtomicBehaviour obj)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}