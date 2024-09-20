using System;
using Atomic.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class SwitchToRangeWeaponAIAction : IBlackboardAction
    {
        public void Invoke(IBlackboard blackboard)
        {
            blackboard
                .GetCharacter()
                .GetComponent<SwitchWeaponComponent>()
                .SwitchWeaponTo<RangeWeapon>();
        }
    }
}