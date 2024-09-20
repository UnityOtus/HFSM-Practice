using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(HealthComponent))]
    public sealed class TakeDamageComponent : MonoBehaviour
    {
        public event Action<int> OnDamageTaken; 

        private HealthComponent _healthComponent;

        private void Awake()
        {
            _healthComponent = this.GetComponent<HealthComponent>();
        }
        
        [Button]
        public bool TakeDamage(int damage)
        {
            if (_healthComponent.Current <= 0)
            {
                return false;
            }

            _healthComponent.Current -= damage;
            this.OnDamageTaken?.Invoke(damage);
            return true;
        }
    }
}