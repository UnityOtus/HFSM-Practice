using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(DealDamageComponent), typeof(HitSphereComponent))]
    public sealed class MeleeWeapon : Weapon
    {
        private DealDamageComponent _dealDamageComponent;
        private HitSphereComponent _hitComponent;

        private void Awake()
        {
            _dealDamageComponent = this.GetComponent<DealDamageComponent>();
            _hitComponent = this.GetComponent<HitSphereComponent>();
        }
        
        [Button]
        public override bool CanFire()
        {
            return true;
        }

        [Button]
        public override void Fire()
        {
            _hitComponent.Hit(_dealDamageComponent.DealDamage);
        }
    }
}