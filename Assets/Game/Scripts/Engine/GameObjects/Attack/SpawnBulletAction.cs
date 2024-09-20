using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Game.Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Content
{
    [Serializable]
    public sealed class SpawnBulletAction : IAtomicAction
    {
        private Transform firePosition;
        private AtomicObject bulletPrefab;

        public void Compose(Transform firePosition, AtomicObject bulletPrefab)
        {
            this.firePosition = firePosition;
            this.bulletPrefab = bulletPrefab;
        }
        
        [Button]
        public void Invoke()
        {
            Vector3 position = this.firePosition.position;
            Quaternion rotation = this.firePosition.rotation;
            GameObject.Instantiate(this.bulletPrefab, position, rotation, null);
        }
    }
}