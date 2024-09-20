using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Game.Engine;
using UnityEditor;
using UnityEngine;

namespace Game.Engine
{
    public sealed class MeleeWeapon : Weapon
    { 
        public override IAtomicFunction<bool> FireCondition => this.hitCondiiton;
        
        public override IAtomicAction FireAction => this.hitAction;
        
        [SerializeField]
        private AndCondition hitCondiiton;

        [SerializeField]
        private Transform hitCenter;

        [SerializeField]
        private AtomicValue<float> hitRadius;

        [SerializeField]
        private MeleeComponent hitAction;

        [SerializeField]
        private AtomicValue<LayerMask> layerMask;

        [SerializeField]
        private AtomicVariable<int> damage;

        [SerializeField]
        private AtomicFunction<IAtomicObject, bool> damageCondition;

        [SerializeField]
        private DealDamageComponent damageComponent;

        private void Awake()
        {
            this.Compose();
        }

        private void Compose()
        {
            this.hitAction.Compose(
                this.damageCondition,
                this.damageComponent,
                this.hitCenter.AsFunction(it => (Vector2) it.position),
                this.hitRadius,
                this.layerMask
            );

            this.damageCondition.Compose(_ => true);
            this.damageComponent.Compose(this.damage);
        }

        private void OnDrawGizmos()
        {
            if (this.hitCenter != null)
            {
                Handles.color = Color.red;
                Handles.DrawWireDisc(this.hitCenter.position, Vector3.forward, this.hitRadius.Value);
            }
        }
    }
}