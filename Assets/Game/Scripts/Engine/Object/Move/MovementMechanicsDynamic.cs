using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    public sealed class MovementMechanicsDynamic : IFixedUpdate
    {
        private readonly IAtomicObject entity;

        public MovementMechanicsDynamic(IAtomicObject entity)
        {
            this.entity = entity;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!this.entity.TryGet(CommonAPI.Rigidbody, out Rigidbody2D rigidbody) ||
                !this.entity.TryGet(MoveAPI.MoveEnabled, out IAtomicValue<bool> moveEnabled) ||
                !this.entity.TryGet(MoveAPI.MoveDirection, out IAtomicValue<float> moveDirection) ||
                !this.entity.TryGet(MoveAPI.MoveSpeed, out IAtomicValue<float> moveSpeed))
            {
                return;
            }
            
            float speedX = 0.0f;
            float speedY = rigidbody.velocity.y;

            if (moveEnabled.Value)
            {
                speedX = moveDirection.Value * moveSpeed.Value;
            }

            rigidbody.velocity = new Vector2(speedX, speedY);
        }
    }
}