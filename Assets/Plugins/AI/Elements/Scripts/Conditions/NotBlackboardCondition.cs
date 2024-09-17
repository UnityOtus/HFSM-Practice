using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.AI
{
    [Serializable, InlineProperty]
    public sealed class NotBlackboardCondition : IBlackboardCondition
    {
        [GUIColor(0.74f, 0.43f, 0.43f)]
        [SerializeReference, LabelText("NOT")]
        private IBlackboardCondition condition;

        public NotBlackboardCondition()
        {
        }

        public NotBlackboardCondition(IBlackboardCondition condition)
        {
            this.condition = condition;
        }

        public bool Invoke(IBlackboard blackboard)
        {
            if (this.condition == null)
            {
                return false;
            }
            
            return !this.condition.Invoke(blackboard);
        }
    }
}