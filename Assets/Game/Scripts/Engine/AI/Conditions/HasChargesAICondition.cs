using System;
using Atomic.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class HasChargesAICondition : IBlackboardCondition
    {
        public bool Invoke(IBlackboard blackboard)
        {
            return blackboard.GetCharacter().GetComponent<WeaponInventoryComponent>().FindWeapon<RangeWeapon>()
                .Charges > 0;
        }
    }
}