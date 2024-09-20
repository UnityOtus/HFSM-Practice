using Game.Content;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(FireBulletComponent))]
    public sealed class RangeWeapon : Weapon
    {
        public int Charges => this.charges;

        [SerializeField]
        private Timer timer;

        [SerializeField]
        private int charges;

        private FireBulletComponent _fireBulletComponent;

        private void Awake()
        {
            _fireBulletComponent = this.GetComponent<FireBulletComponent>();
        }

        public void FixedUpdate()
        {
            this.timer.Tick(Time.fixedDeltaTime);
        }

        public override bool CanFire()
        {
            return this.charges > 0 && this.timer.IsEnded();
        }

        public override void Fire()
        {
            if (this.CanFire())
            {
                _fireBulletComponent.Fire();
                this.charges--;
                this.timer.Reset();
            }
        }
    }
}