using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.AI
{
    [Serializable, InlineProperty]
    public sealed class OrBlackboardCondition : IBlackboardCondition
    {
        [GUIColor(0.43f, 0.63f, 0.74f)]
        [SerializeReference, LabelText("OR")]
        private IBlackboardCondition[] conditions;

        public OrBlackboardCondition()
        {
        }

        public OrBlackboardCondition(IBlackboardCondition[] conditions)
        {
            this.conditions = conditions;
        }

        public bool Invoke(IBlackboard blackboard)
        {
            if (this.conditions == null)
            {
                return false;
            }
            
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                IBlackboardCondition condition = this.conditions[i];
                if (condition.Invoke(blackboard))
                {
                    return true;
                }
            }

            return false;
        }
    }
}