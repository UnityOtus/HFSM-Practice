using System;
using System.Collections.Generic;
using Atomic.Elements;
using GameEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class AndExpression : AtomicExpression<bool>
    {
        public AndExpression()
        {
        }

        public AndExpression(IEnumerable<IAtomicValue<bool>> members) : base(members)
        {
        }

        protected override bool Invoke(IReadOnlyList<IAtomicValue<bool>> members)
        {
            foreach (var member in members)
            {
                if (!member.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}