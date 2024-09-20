using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [RequireComponent(typeof(MoveComponent))]
    public sealed class LookTowardsMovementMechanics : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private LookComponent _lookComponent;

        private void Awake()
        {
            _moveComponent = this.GetComponent<MoveComponent>();
            _lookComponent = this.GetComponent<LookComponent>();
        }

        private void FixedUpdate()
        {
            float moveDirection = _moveComponent.CurrentDirection;
            if (moveDirection != 0)
            {
                _lookComponent.CurrentDirection = moveDirection;
            }
        }
    }
}