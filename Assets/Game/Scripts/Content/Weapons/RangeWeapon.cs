using Atomic.Elements;
using Atomic.Objects;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class RangeWeapon : Weapon
    {
        public override IAtomicFunction<bool> FireCondition => this.fireCondiiton;
        
        public override IAtomicAction FireAction => this.fireAction;

        public IAtomicValue<int> Charges => this.charges;
        
        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private AndExpression fireCondiiton;

        [SerializeField]
        private AtomicAction fireAction;

        [SerializeField]
        private AtomicObject bulletPrefab;

        [SerializeField]
        private SpawnBulletAction spawnBulletAction;

        [SerializeField]
        private Countdown countdown;

        [SerializeField]
        private AtomicVariable<int> charges;

        private void Awake()
        {
            this.spawnBulletAction.Compose(
                this.firePoint, this.bulletPrefab
            );
            
            this.fireCondiiton.Append(new AtomicFunction<bool>(() => this.charges.Value > 0));
            
            this.fireAction.Compose(() =>
            {
                if (this.countdown.IsEnded())
                {
                    this.spawnBulletAction.Invoke();
                    this.charges.Value--;
                    this.countdown.Reset();
                }
            });
        }

        public void FixedUpdate()
        {
            this.countdown.Tick(Time.fixedDeltaTime);
        }
    }
}