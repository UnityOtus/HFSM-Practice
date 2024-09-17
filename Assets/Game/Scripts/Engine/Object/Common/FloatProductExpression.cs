using System;
using System.Collections.Generic;
using Atomic.Elements;
using GameEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class FloatProductExpression : AtomicExpression<float>
    {
        protected override float Invoke(IReadOnlyList<IAtomicValue<float>> members)
        {
            if (members.Count == 0)
            {
                return 0;
            }
            
            float result = 1;
            
            for (int i = 0, count = members.Count; i < count; i++)
            {
                IAtomicValue<float> member = members[i];
                result *= member.Value;
            }

            return result;
        }
    }
}