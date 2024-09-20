using System;
using Atomic.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class HasAmmoAICondition : IBlackboardCondition
    {
        public bool Invoke(IBlackboard blackboard)
        {
            var weaponInventoryComponent = blackboard.GetCharacter().GetComponent<WeaponInventoryComponent>();
            RangeWeapon rangeWeapon = weaponInventoryComponent.FindWeapon<RangeWeapon>();
            return rangeWeapon.Charges > 0;
        }
    }
}