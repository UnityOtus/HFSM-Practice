using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    public sealed class MoveAnimMechanicsDynamic : IUpdate
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private readonly IAtomicObject target;

        public MoveAnimMechanicsDynamic(IAtomicObject target)
        {
            this.target = target;
        }

        public void OnUpdate(float deltaTime)
        {
            if (!this.target.TryGet(CommonAPI.Animator, out Animator animator) || 
                !this.target.TryGetValue<bool>(MoveAPI.IsMoving, out var isMoving)) 
            {
                return;
            }
            
            animator.SetBool(IsMoving, isMoving.Value);
        }
    }
}