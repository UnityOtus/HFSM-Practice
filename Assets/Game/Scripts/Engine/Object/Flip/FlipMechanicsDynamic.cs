using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    public sealed class FlipMechanicsDynamic : IFixedUpdate
    {
        private readonly IAtomicObject entity;
        
        private readonly Transform _transform;

        public FlipMechanicsDynamic(IAtomicObject entity)
        {
            this.entity = entity;
            _transform = this.entity.Get<Transform>(CommonAPI.Transform);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!this.entity.TryGet(MoveAPI.MoveDirection, out IAtomicValue<float> moveDirection))
            {
                return;
            }

            if (moveDirection.Value != 0)
            {
                _transform.localScale = new Vector3(moveDirection.Value, 1, 1);
            }
        }
    }
}