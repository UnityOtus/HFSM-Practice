using System;
using Atomic.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class SwitchToMeleeWeaponAIAction : IBlackboardAction
    {
        public void Invoke(IBlackboard blackboard)
        {
            blackboard.GetCharacter().GetComponent<SwitchWeaponComponent>().SwitchWeaponTo<MeleeWeapon>();
        }
    }
}