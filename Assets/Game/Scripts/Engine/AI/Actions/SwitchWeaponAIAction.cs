using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class SwitchToRangedWeaponAIAction : IBlackboardAction
    {
        public void Invoke(IBlackboard blackboard)
        {
            blackboard.GetCharacter().GetComponent<SwitchWeaponComponent>().SwitchWeaponTo<RangeWeapon>();
        }
    }
}