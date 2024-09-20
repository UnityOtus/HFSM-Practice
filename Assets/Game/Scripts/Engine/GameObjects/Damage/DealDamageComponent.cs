using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class DealDamageComponent : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        public bool DealDamage(GameObject target)
        {
            if (target.TryGetComponent(out TakeDamageComponent damageComponent))
            {
                return damageComponent.TakeDamage(this.damage);
            }

            return false;
        }
    }
}