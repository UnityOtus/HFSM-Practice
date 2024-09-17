using System;
using System.Collections.Generic;
using Atomic.Elements;
using GameEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class FloatSumExpression : AtomicExpression<float>
    {
        protected override float Invoke(IReadOnlyList<IAtomicValue<float>> members)
        {
            float result = 0;
            
            for (int i = 0, count = members.Count; i < count; i++)
            {
                IAtomicValue<float> member = members[i];
                result += member.Value;
            }

            return result;
        }
    }
}