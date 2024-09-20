using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(MoveComponent))]
    public sealed class FlipMechanics : MonoBehaviour
    {
        private MoveComponent _moveComponent;

        private void Awake()
        {
            _moveComponent = this.GetComponent<MoveComponent>();
        }

        private void FixedUpdate()
        {
            float moveDirection = _moveComponent.MoveDirection;
            if (moveDirection == 0)
            { 
                return;
            }

            float angle = moveDirection > 0 ? 0 : 180;
            this.transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}