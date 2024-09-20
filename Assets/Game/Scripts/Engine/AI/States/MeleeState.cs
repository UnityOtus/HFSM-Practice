using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class MeleeState : IState
    {
        public string Name => "Melee State";

        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            
        }

        public void OnEnter(IBlackboard blackboard)
        {
            blackboard.SetCurrentAttackDistance(blackboard.GetMeleeAttackDistance());
            blackboard.GetCharacter().GetComponent<SwitchWeaponComponent>().SwitchWeaponTo<MeleeWeapon>();
        }

        public void OnExit(IBlackboard blackboard)
        {
            
        }
    }
}