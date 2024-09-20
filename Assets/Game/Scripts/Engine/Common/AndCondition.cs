using System;
using System.Collections.Generic;

namespace Game.Engine
{
    [Serializable]
    public sealed class AndCondition
    {
        private List<Func<bool>> conditions = new();

        public void AddCondition(Func<bool> condition)
        {
            this.conditions.Add(condition);
        }

        public bool Invoke()
        {
            foreach (var member in this.conditions)
            {
                if (!member.Invoke())
                {
                    return false;
                }
            }

            return true;
        }
    }
}