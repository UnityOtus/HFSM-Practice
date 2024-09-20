using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(DealDamageComponent))]
    public sealed class MeleeWeapon : Weapon
    {
        private DealDamageComponent _dealDamageComponent;
        private HitSphereComponent _hitComponent;

        private void Awake()
        {
            _dealDamageComponent = this.GetComponent<DealDamageComponent>();
            _hitComponent = this.GetComponent<HitSphereComponent>();
        }
        
        public override bool CanFire()
        {
            return true;
        }

        public override void Fire()
        {
            _hitComponent.Hit(_dealDamageComponent.DealDamage);
        }
    }
}