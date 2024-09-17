using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Sirenix.OdinInspector;

namespace Game.Engine
{
    [Serializable]
    public sealed class DealDamageAction : IAtomicAction<IAtomicObject>
    {
        private IAtomicValue<int> damage;

        public void Compose(IAtomicValue<int> damage)
        {
            this.damage = damage;
        }

        [Button]
        public void Invoke(IAtomicObject target)
        {
            if (!target.Is(ObjectType.Damageable))
                return;

            target.InvokeAction(HealthAPI.TakeDamageAction, this.damage.Value);
        }
    }
}