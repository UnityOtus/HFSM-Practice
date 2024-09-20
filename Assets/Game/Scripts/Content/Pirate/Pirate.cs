using System;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [Serializable]
    public sealed class Pirate : MonoBehaviour
    {
        [SerializeField]
        private MoveComponent _moveComponent;

        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private AttackComponent _attackComponent;

        [SerializeField]
        private DeathComponent _deathComponent;

        private void Start()
        {
            _moveComponent.AddCondition(_healthComponent.IsAlive);
            _attackComponent
                .AddCondition(_healthComponent.IsAlive)
                .AddCondition(_moveComponent.IsNotMoving);
        }

        private void OnEnable()
        {
            _deathComponent.OnDeath += this.OnDeath;
        }

        private void OnDisable()
        {
            _deathComponent.OnDeath -= this.OnDeath;
        }

        private void OnDeath()
        {
            Destroy(this.gameObject);
        }
    }
}