using System;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(HealthComponent))]
    public sealed class DeathComponent : MonoBehaviour
    {
        public event Action OnDeath;

        private HealthComponent _healthComponent;
        
        private void Awake()
        {
            _healthComponent = this.GetComponent<HealthComponent>();
        }

        public void OnEnable()
        {
            _healthComponent.OnChanged += OnHitPointsChanged;
        }

        public void OnDisable()
        {
            _healthComponent.OnChanged -= OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int hp)
        {
            if (hp <= 0)
            {
                this.OnDeath?.Invoke();
            }
        }
    }
}