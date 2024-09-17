using System;
using AIModule;
using Atomic.Elements;
using Atomic.Objects;
using Modules.AI;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class HasCharacterWeaponChargesBlackboardCondition : IBlackboardCondition
    {
        public bool Invoke(IBlackboard blackboard)
        {
            return blackboard.TryGetCharacter(out IAtomicObject character) &&
                   character.TryGet(AttackAPI.WeaponCharges, out IAtomicValue<int> charges) &&
                   charges.Value > 0;
        }
    }
}