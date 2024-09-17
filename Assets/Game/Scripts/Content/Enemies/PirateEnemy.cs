using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [DefaultExecutionOrder(-1000)]
    public sealed class PirateEnemy : AtomicBehaviour
    {
        [Section]
        public PirateEnemy_Core core;

        [Section]
        public PirateEnemy_View view;

        public override void Compose()
        {
            base.Compose();
            this.core.Compose();
            this.view.Compose(this.core);
        }

        private void Awake()
        {
            this.Compose();
        }

        private void OnEnable()
        {
            this.Enable();
            this.view.Enable();
        }

        private void OnDisable()
        {
            this.Disable();
            this.view.Disable();
        }

        private void FixedUpdate()
        {
            float fixedDeltaTime = Time.fixedDeltaTime;
            this.OnFixedUpdate(fixedDeltaTime);
            this.core.OnFixedUpdate(fixedDeltaTime);
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            this.OnUpdate(deltaTime);
            this.view.OnUpdate(deltaTime);
        }
    }

    [Serializable]
    public sealed class PirateEnemy_Core : IFixedUpdate
    {
        [SerializeField]
        public GameObject gameObject;
        
        [Get(CommonAPI.Rigidbody)]
        public Rigidbody2D rigidbody2D;

        [Get(CommonAPI.Transform)]
        public Transform transform;

        [Section]
        public HealthComponent healthComponent;

        [Section]
        public GroundedComponent groundedComponent;

        [Section]
        public MoveComponent moveComponent;

        [Section]
        public AttackComponent attackComponent;

        [Section]
        public MeleeWeapon meleeWeapon;

        [Get(CommonAPI.FlipDirection)]
        [SerializeField]
        private AtomicVariable<float> flipDirection;

        private FlipMechanics flipMechanics;

        private PirateLookMechanics lookMechanics;

        public void Compose()
        {
            this.healthComponent.Compose();
            this.groundedComponent.Compose();

            this.moveComponent.Let(it =>
            {
                it.MoveEnabled.Append(this.healthComponent.IsAlive);
                it.Compose();
            });

            this.attackComponent.Let(it =>
            {
                it.Compose();
                it.AttackCondition.Append(this.healthComponent.IsAlive);
                it.AttackCondition.Append(this.moveComponent.IsMoving.AsNot());
            });

            this.flipMechanics = new FlipMechanics(this.flipDirection, this.transform);
            this.lookMechanics = new PirateLookMechanics(this.moveComponent.MoveDirection, this.flipDirection);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            this.moveComponent.OnFixedUpdate(deltaTime);
            this.groundedComponent.OnFixedUpdate(deltaTime);
            this.flipMechanics.OnFixedUpdate(deltaTime);
            this.lookMechanics.OnFixedUpdate(deltaTime);

            if (!this.healthComponent.IsAlive.Value)
            {
                gameObject.SetActive(false);
            }
        }
    }

    [Serializable]
    public sealed class PirateEnemy_View : IEnable, IDisable, IUpdate
    {
        [Get(CommonAPI.Animator)]
        public Animator animator;

        public AnimatorDispatcher dispatcher;

        [Get(CommonAPI.SpriteRenderer)]
        public SpriteRenderer spriteRenderer;

        private MoveAnimMechanics moveMechanics;
        private AttackAnimMechanics attackMechanics;
        private HitAnimListener hitListener;

        public void Compose(PirateEnemy_Core core)
        {
            this.moveMechanics = new MoveAnimMechanics(this.animator, core.moveComponent.IsMoving);
            this.attackMechanics = new AttackAnimMechanics(this.animator, core.attackComponent.AttackEvent);
            this.hitListener = new HitAnimListener(this.dispatcher, core.meleeWeapon.FireAction);
        }

        public void Enable()
        {
            this.attackMechanics.Enable();
            this.hitListener.Enable();
        }

        public void Disable()
        {
            this.attackMechanics.Disable();
            this.hitListener.Disable();
        }

        public void OnUpdate(float deltaTime)
        {
            this.moveMechanics.Update();
        }
    }
}