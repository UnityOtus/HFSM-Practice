using Atomic.Objects;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [Is(ObjectType.Character)]
    public sealed class Dummy : AtomicObject
    {
        [Get(CommonAPI.Transform)]
        public new Transform transform;
        
        [Section]
        public HealthComponent healthComponent;

        public new Collider2D collider;

        public Animator animator;

        private void Awake()
        {
            this.Compose();
            this.healthComponent.Compose();
            this.healthComponent.DeathEvent.Subscribe(() => this.collider.enabled = false);
            this.healthComponent.DamageEvent.Subscribe(_ =>
            {
                if (this.healthComponent.IsAlive.Value)
                {
                    this.animator.Play("TakeDamage", -1, -0);
                }
            });
            this.healthComponent.DeathEvent.Subscribe(() =>
            {
                this.animator.Play("Destroy", -1, 0);
            });
        }

        private void OnEnable()
        {
            this.healthComponent.OnEnable();
        }

        private void OnDisable()
        {
            this.healthComponent.OnDisable();
        }
    }
}