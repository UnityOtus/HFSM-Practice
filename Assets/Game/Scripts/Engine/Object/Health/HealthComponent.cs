using System;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    [Is(ObjectType.Damageable)]
    public class HealthComponent : IDisposable
    {
        public IAtomicObservable DeathEvent => this.deathEvent;
        public IAtomicObservable<int> DamageEvent => this.takeDamageEvent;
        
        [Get(HealthAPI.IsAlive)]
        public IAtomicValue<bool> IsAlive => this.isAlive;

        [SerializeField]
        private HitPoints hitPoints = new(5, 5);

        [SerializeField]
        private AtomicFunction<bool> isAlive;

        private readonly AtomicEvent deathEvent = new();
        
        [Get(HealthAPI.TakeDamageAction)]
        [SerializeField]
        private TakeDamageAction takeDamageAction = new();

        [SerializeField]
        private AtomicEvent<int> takeDamageEvent;
        
        private DeathMechanics deathMechanics;
        
        public void Compose()
        {
            takeDamageAction.Compose(hitPoints, this.takeDamageEvent);
            deathMechanics = new DeathMechanics(hitPoints, deathEvent);
            isAlive.Compose(() => this.hitPoints.Current > 0);
        }
        
        public void OnEnable()
        {
            deathMechanics.OnEnable();
        }

        public void OnDisable()
        {
            deathMechanics.OnDisable();
        }
        
        public void Dispose()
        {
            deathEvent?.Dispose();
        }
    }
}