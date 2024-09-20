using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class DealDamageComponent : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        private AndCondition conditions = new();

        public void AddCondition(Func<bool> condition)
        {
            this.conditions.AddCondition(condition);
        }

        public bool DealDamage(GameObject target)
        {
            if (this.conditions.Invoke() && target.TryGetComponent(out TakeDamageComponent damageComponent))
            {
                return damageComponent.TakeDamage(this.damage);
            }

            return false;
        }
    }
}