using System;
using UnityEngine;

namespace Game.Content
{
    [Serializable]
    public sealed class FireBulletComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform firePoint;
        
        [SerializeField]
        private GameObject bulletPrefab;

        public GameObject Fire()
        {
            Vector3 position = this.firePoint.position;
            Quaternion rotation = this.firePoint.rotation;
            return Instantiate(this.bulletPrefab, position, rotation, null);
        }
    }
}