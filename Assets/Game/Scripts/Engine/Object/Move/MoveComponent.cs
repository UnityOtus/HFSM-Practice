using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;
using UnityEngine.Serialization;

// ReSharper disable MemberInitializerValueIgnored

namespace Game.Engine
{
    [Is(ObjectType.Moveable)]
    [Serializable]
    public sealed class MoveComponent : IDisposable, IFixedUpdate
    {
        [Get(MoveAPI.MoveDirection)]
        public IAtomicVariableObservable<float> MoveDirection => this.moveDirection;

        [Get(MoveAPI.MoveSpeedExpression)]
        public IAtomicExpression<float> MoveSpeedExpression => this.fullSpeed;

        [Get(MoveAPI.IsMoving)]
        public IAtomicValue<bool> IsMoving => this.isMoving;

        [Get(MoveAPI.MoveSpeed)]
        public IAtomicValue<float> MoveSpeed => this.fullSpeed;

        [Get(MoveAPI.MoveEnabled)]
        public IAtomicExpression<bool> MoveEnabled => this.moveEnabled;

        [SerializeField]
        private Rigidbody2D rigidbody;

        [SerializeField]
        private AtomicVariable<float> moveDirection = new();

        [SerializeField]
        private AndExpression moveEnabled = new();

        [SerializeField]
        private AtomicFunction<bool> isMoving = new();

        private MovementMechanics movementMechanics;

        [SerializeField, FormerlySerializedAs("moveSpeed")]
        private AtomicValue<float> baseSpeed = new(0);

        [SerializeField]
        private FloatProductExpression fullSpeed;

        public MoveComponent(Rigidbody2D rigidbody, float speed = 0)
        {
            this.rigidbody = rigidbody;
            this.baseSpeed = new AtomicValue<float>(speed);
            this.Compose();
        }

        public void Compose()
        {
            this.movementMechanics = new MovementMechanics(
                this.rigidbody, this.moveEnabled, this.moveDirection, this.fullSpeed
            );

            this.isMoving.Compose(() => this.fullSpeed.Invoke() != 0 &&
                                        this.moveDirection.Value != 0 &&
                                        this.moveEnabled.Invoke()
            );

            this.fullSpeed.Append(this.baseSpeed);
        }

        public void Dispose()
        {
            this.moveDirection?.Dispose();
        }

        public void OnFixedUpdate(float deltaTime)
        {
            this.movementMechanics.FixedUpdate();
        }
    }
}