using Game.Content;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(FireBulletComponent))]
    public sealed class RangeWeapon : Weapon
    {
        public int Charges => this.charges;

        [SerializeField]
        private int charges;
        
        [SerializeField]
        private Timer countdown;

        private FireBulletComponent _fireBulletComponent;

        private void Awake()
        {
            _fireBulletComponent = this.GetComponent<FireBulletComponent>();
        }

        public void FixedUpdate()
        {
            this.countdown.Tick(Time.fixedDeltaTime);
        }

        public override bool CanFire()
        {
            return this.charges > 0 && this.countdown.IsEnded();
        }

        public override void Fire()
        {
            if (this.CanFire())
            {
                _fireBulletComponent.Fire();
                this.charges--;
                this.countdown.Reset();
            }
        }
    }
}