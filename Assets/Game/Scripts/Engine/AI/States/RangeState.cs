using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class RangeState : IState
    {
        public string Name => "Range State";

        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            
        }

        public void OnEnter(IBlackboard blackboard)
        {
            blackboard.SetCurrentAttackDistance(blackboard.GetRangeAttackDistance());
            blackboard.GetCharacter().GetComponent<SwitchWeaponComponent>().SwitchWeaponTo<RangeWeapon>();
        }

        public void OnExit(IBlackboard blackboard)
        {
            
        }
    }
}