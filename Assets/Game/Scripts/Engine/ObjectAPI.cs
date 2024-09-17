using Atomic.Elements;
using Atomic.Extensions;
using UnityEngine;

namespace Game.Engine
{
    public static class HealthAPI
    {
        [Contract(typeof(IAtomicAction<int>))]
        public const string TakeDamageAction = nameof(TakeDamageAction);

        [Contract(typeof(IAtomicValue<bool>))]
        public const string IsAlive = nameof(IsAlive);
    }

    public static class AttackAPI
    {
        [Contract(typeof(IAtomicAction))]
        public const string AttackRequest = nameof(AttackRequest);
        
        [Contract(typeof(IAtomicValue<int>))]
        public const string WeaponCharges = nameof(WeaponCharges);
        
        [Contract(typeof(IAtomicAction))]
        public const string SwitchToMeleeWeapon = nameof(SwitchToMeleeWeapon);

        [Contract(typeof(IAtomicAction))]
        public const string SwitchToRangeWeapon = nameof(SwitchToRangeWeapon);
    }

    public static class CommonAPI
    {
        [Contract(typeof(Transform))]
        public const string Transform = nameof(Transform);

        [Contract(typeof(IAtomicValue<bool>))]
        public const string IsGrounded = nameof(IsGrounded);

        [Contract(typeof(Rigidbody2D))]
        public const string Rigidbody = nameof(Rigidbody);

        [Contract(typeof(Animator))]
        public const string Animator = nameof(Animator);

        [Contract(typeof(IAtomicEvent))]
        public const string CollectCoinEvent = nameof(CollectCoinEvent);

        [Contract(typeof(IAtomicAction))]
        public const string DeathAction = nameof(DeathAction);

        [Contract(typeof(IAtomicVariable<float>))]
        public const string FlipDirection = nameof(FlipDirection);


        [Contract(typeof(EffectManager))]
        public const string EffectManager = nameof(EffectManager);

        [Contract(typeof(SpriteRenderer))]
        public const string SpriteRenderer = nameof(SpriteRenderer);
    }

    public static class JumpAPI
    {
        [Contract(typeof(IAtomicAction))]
        public const string JumpAction = nameof(JumpAction);

        [Contract(typeof(IAtomicValue<float>))]
        public const string JumpForce = nameof(JumpForce);

        [Contract(typeof(IAtomicAction))]
        public const string JumpEvent = nameof(JumpEvent);

        [Contract(typeof(IAtomicValue<bool>))]
        public const string JumpEnabled = nameof(JumpEnabled);

        [Contract(typeof(IAtomicExpression<float>))]
        public const string JumpForceExpression = nameof(JumpForceExpression);
    }

    public static class MoveAPI
    {
        [Contract(typeof(IAtomicValue<bool>))]
        public const string IsMoving = nameof(IsMoving);

        [Contract(typeof(IAtomicVariable<float>))]
        public const string MoveDirection = nameof(MoveDirection);

        [Contract(typeof(IAtomicValue<bool>))]
        public const string MoveEnabled = nameof(MoveEnabled);

        [Contract(typeof(IAtomicValue<float>))]
        public const string MoveSpeed = nameof(MoveSpeed);

        [Contract(typeof(IAtomicExpression<float>))]
        public const string MoveSpeedExpression = nameof(MoveSpeedExpression);
    }
}