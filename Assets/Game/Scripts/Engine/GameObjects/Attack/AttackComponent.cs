using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class AttackComponent : MonoBehaviour
    {
        public event Action OnAttack;

        private readonly AndCondition attackCondition = new();

        private Action attackAction;

        public AttackComponent AddCondition(Func<bool> condition)
        {
            this.attackCondition.AddCondition(condition);
            return this;
        }

        public void AddAction(Action action)
        {
            this.attackAction += action;
        }

        public void Attack()
        {
            if (this.attackCondition.Invoke())
            {
                this.attackAction?.Invoke();
                this.OnAttack?.Invoke();
            }
        }
    }
}