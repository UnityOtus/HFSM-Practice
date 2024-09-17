using System;
using AIModule;
using Atomic.Extensions;
using Atomic.Objects;
using Modules.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class SwitchToRangeCharacterWeaponAction : IBlackboardAction
    {
        public void Invoke(IBlackboard blackboard)
        {
            if (blackboard.TryGetCharacter(out IAtomicObject character))
            {
                character.InvokeAction(AttackAPI.SwitchToRangeWeapon);
            }
        }
    }
}