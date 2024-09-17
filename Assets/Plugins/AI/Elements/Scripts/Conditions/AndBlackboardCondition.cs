using System;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.AI
{
    [Serializable, InlineProperty]
    public sealed class AndBlackboardCondition : IBlackboardCondition
    {
        [GUIColor(0.37f, 0.75f, 0.55f)]
        [SerializeReference, LabelText("AND")]
        private IBlackboardCondition[] conditions;

        public AndBlackboardCondition()
        {
        }

        public AndBlackboardCondition(IBlackboardCondition[] conditions)
        {
            this.conditions = conditions;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke(IBlackboard blackboard)
        {
            if (this.conditions == null)
            {
                return true;
            }
            
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                IBlackboardCondition condition = this.conditions[i];
                if (!condition.Invoke(blackboard))
                {
                    return false;
                }
            }

            return true;
        }
    }
}