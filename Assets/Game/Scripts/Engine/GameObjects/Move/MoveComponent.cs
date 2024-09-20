using System;
using UnityEngine;

// ReSharper disable MemberInitializerValueIgnored

namespace Game.Engine
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class MoveComponent : MonoBehaviour
    {
        private const float MIN_SPEED = 0.1f;

        public float CurrentDirection
        {
            get => this.currentDirection;
            set => this.currentDirection = value;
        }

        [SerializeField]
        private float currentDirection;

        [SerializeField]
        private float moveSpeed;

        private readonly AndCondition conditions = new();

        private float speedX;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = this.GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            this.speedX = this.conditions.Invoke() ? this.currentDirection * this.moveSpeed : 0;
            _rigidbody.velocity = new Vector2(speedX, _rigidbody.velocity.y);
        }

        public MoveComponent AddCondition(Func<bool> condition)
        {
            this.conditions.AddCondition(condition);
            return this;
        }

        public void Stop()
        {
            this.currentDirection = 0;
        }

        public bool IsMoving()
        {
            return Mathf.Abs(this.speedX) >= MIN_SPEED;
        }

        public bool IsNotMoving()
        {
            return !this.IsMoving();
        }
    }
}