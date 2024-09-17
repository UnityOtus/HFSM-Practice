using System;
using AIModule;
using Modules.AI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable, InlineProperty]
    public sealed class AttackDataInstaller : IBlackboardInstaller
    {
        [HorizontalGroup]
        [BlackboardKey]
        [SerializeField, HideLabel]
        private int key = BlackboardAPI.AttackData;
        
        [HorizontalGroup]
        [SerializeField]
        private AttackData attackData;
        
        public void Install(IBlackboard blackboard)
        {
            blackboard.SetStruct(this.key, this.attackData);
        }
    }
}