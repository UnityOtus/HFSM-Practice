using Atomic.Elements;
using UnityEngine;

namespace Game.Engine
{
    public sealed class AttackController
    {
        private readonly IAtomicAction attackAction;

        public AttackController(IAtomicAction attackAction)
        {
            this.attackAction = attackAction;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.attackAction?.Invoke();
            }
        }
    }
}