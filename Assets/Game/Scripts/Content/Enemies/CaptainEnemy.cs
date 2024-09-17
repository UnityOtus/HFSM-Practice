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
    public sealed class CaptainEnemy : AtomicBehaviour
    {
        [Section]
        public CaptainEnemy_Core core;

        [Section]
        public CaptainEnemy_View view;

        public override void Compose()
        {
            base.Compose();
            this.core.Compose(this);
            this.view.Compose(this.core);
        }

        private void Awake()
        {
            this.Compose();
        }

        private void OnEnable()
        {
            this.Enable();
            this.core.Enable();
            this.view.Enable();
        }

        private void OnDisable()
        {
            this.Disable();
            this.core.Disable();
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
    public sealed class CaptainEnemy_Core : IFixedUpdate, IEnable, IDisable
    {
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

        [Header("Weapons")]
        public AtomicVariable<Weapon> currentWeapon;
        
        [Get(AttackAPI.SwitchToMeleeWeapon)]
        public AtomicEvent switchToMeleeWeaponAction;

        [Get(AttackAPI.SwitchToRangeWeapon)]
        public AtomicEvent switchToRangeWeaponAction;

        public Countdown switchWeaponCountdown;

        public MeleeWeapon meleeWeapon;
        public RangeWeapon rangeWeapon;

        [Get(CommonAPI.FlipDirection)]
        [SerializeField]
        private AtomicVariable<float> flipDirection;

        private FlipMechanics flipMechanics;

        private EnemyLookMechanics lookMechanics;

        public void Compose(AtomicObject obj)
        {
            this.healthComponent.Let(it =>
            {
                it.Compose();
                it.DeathEvent.Subscribe(() => GameObject.Destroy(obj.gameObject));
            });
            
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
                it.AttackCondition.Append(new AtomicFunction<bool>(this.switchWeaponCountdown.IsEnded));
            });

            this.switchToMeleeWeaponAction.Subscribe(() =>
            {
                this.currentWeapon.Value = this.meleeWeapon;
                this.switchWeaponCountdown.Reset();
            });
            this.switchToRangeWeaponAction.Subscribe(() =>
            {
                this.currentWeapon.Value = this.rangeWeapon;
                this.switchWeaponCountdown.Reset();
            });

            this.flipMechanics = new FlipMechanics(this.flipDirection, this.transform);
            this.lookMechanics = new EnemyLookMechanics(this.moveComponent.MoveDirection, this.flipDirection);

            obj.AddProperty(AttackAPI.WeaponCharges, this.rangeWeapon.Charges);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            this.moveComponent.OnFixedUpdate(deltaTime);
            this.groundedComponent.OnFixedUpdate(deltaTime);
            this.flipMechanics.OnFixedUpdate(deltaTime);
            this.lookMechanics.OnFixedUpdate(deltaTime);
            this.switchWeaponCountdown.Tick(deltaTime);
        }
        
        public void Enable()
        {
            this.healthComponent.OnEnable();
        }

        public void Disable()
        {
            this.healthComponent.OnDisable();
        }
    }

    [Serializable]
    public sealed class CaptainEnemy_View : IEnable, IDisable, IUpdate
    {
        private static int MELEE_TRIGGER = Animator.StringToHash("MeleeAttack");
        private static int RANGE_TRIGGER = Animator.StringToHash("RangeAttack");

        private const string MELEE_ANIM_EVENT = "hit";
        private const string RANGE_ANIM_EVENT = "fire";

        [Get(CommonAPI.Animator)]
        public Animator animator;

        public AnimatorDispatcher dispatcher;

        [Get(CommonAPI.SpriteRenderer)]
        public SpriteRenderer spriteRenderer;

        private MoveAnimMechanics moveMechanics;

        private AnimationEventListener meleeAttackListener;
        private AnimationEventListener rangeAttackListener;

        public void Compose(CaptainEnemy_Core core)
        {
            this.moveMechanics = new MoveAnimMechanics(
                this.animator, core.moveComponent.IsMoving
            );

            this.meleeAttackListener = new AnimationEventListener(
                this.dispatcher, MELEE_ANIM_EVENT, core.meleeWeapon.FireAction
            );

            this.rangeAttackListener = new AnimationEventListener(
                this.dispatcher, RANGE_ANIM_EVENT, core.rangeWeapon.FireAction
            );
            
            core.switchToMeleeWeaponAction.Subscribe(() => 
                this.animator.Play("SwitchToMelee", this.animator.GetLayerIndex("Extra Layer"), 0));
            core.switchToRangeWeaponAction.Subscribe(() => 
                this.animator.Play("SwitchToRange", this.animator.GetLayerIndex("Extra Layer"), 0));
            
            core.attackComponent.AttackEvent.Subscribe(() =>
            {
                Weapon currentWeapon = core.currentWeapon.Value;
                if (currentWeapon == null)
                {
                    return;
                }

                if (!currentWeapon.FireCondition.Invoke())
                {
                    return;
                }

                if (currentWeapon is MeleeWeapon)
                {
                    this.animator.SetTrigger(MELEE_TRIGGER);
                }
                else if (currentWeapon is RangeWeapon)
                {
                    this.animator.SetTrigger(RANGE_TRIGGER);
                }
            });
        }

        public void Enable()
        {
            this.meleeAttackListener.Enable();
            this.rangeAttackListener.Enable();
        }

        public void Disable()
        {
            this.meleeAttackListener.Disable();
            this.rangeAttackListener.Disable();
        }

        public void OnUpdate(float deltaTime)
        {
            this.moveMechanics.Update();
        }
    }
}