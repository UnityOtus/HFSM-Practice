using System;
using Atomic.Behaviours;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class SpawnObjectEffect : IEffect
    {
        [SerializeField]
        private GameObject prefab;

        private GameObject _gameObject;
        
        public void Apply(AtomicBehaviour obj)
        {
            Transform transform = obj.transform;
            _gameObject = GameObject.Instantiate(this.prefab, transform.position, transform.rotation, transform);
        }

        public void Discard(AtomicBehaviour obj)
        {
            GameObject.Destroy(_gameObject);
        }
    }
}