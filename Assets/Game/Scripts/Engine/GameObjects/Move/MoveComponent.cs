using UnityEngine;

// ReSharper disable MemberInitializerValueIgnored

namespace Game.Engine
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class MoveComponent : MonoBehaviour
    {
        private const float MIN_SPEED = 0.1f;
        
        public float MoveDirection
        {
            get => this.moveDirection;
            set => this.moveDirection = value;
        }

        public bool IsMoving
        {
            get { return _rigidbody.velocity.x >= MIN_SPEED; }
        }

        [SerializeField]
        private float moveDirection;

        [SerializeField]
        private float moveSpeed;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = this.GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            float speedX = this.moveDirection * this.moveSpeed;
            float speedY = _rigidbody.velocity.y;
            _rigidbody.velocity = new Vector2(speedX, speedY);
        }
    }
}