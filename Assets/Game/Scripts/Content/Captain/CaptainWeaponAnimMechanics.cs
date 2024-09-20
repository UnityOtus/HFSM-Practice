using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [RequireComponent(typeof(Animator), typeof(AnimatorDispatcher))]
    public sealed class CaptainWeaponAnimMechanics : MonoBehaviour
    {
        private static readonly int MELEE_TRIGGER = Animator.StringToHash("MeleeAttack");
        private static readonly int RANGE_TRIGGER = Animator.StringToHash("RangeAttack");

        private const string MELEE_ANIM_EVENT = "hit";
        private const string RANGE_ANIM_EVENT = "fire";
        private const string EXTRA_LAYER = "Extra Layer";

        private static readonly int SWITCH_TO_MELEE = Animator.StringToHash("SwitchToMelee");
        private static readonly int SWITCH_TO_RANGE = Animator.StringToHash("SwitchToRange");

        [SerializeField]
        private CurrentWeaponComponent _currentWeaponComponent;

        [SerializeField]
        private SwitchWeaponComponent _switchWeaponComponent;

        [SerializeField]
        private AttackComponent _attackComponent;

        private Animator _animator;
        private AnimatorDispatcher _animatorDispatcher;

        private int extraLayer;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
            this.extraLayer = _animator.GetLayerIndex(EXTRA_LAYER);

            _animatorDispatcher = this.GetComponent<AnimatorDispatcher>();
        }

        private void OnEnable()
        {
            _animatorDispatcher.AddListener(MELEE_ANIM_EVENT, this.OnMeleeAttack);
            _animatorDispatcher.AddListener(RANGE_ANIM_EVENT, this.OnRangeAttack);

            _switchWeaponComponent.OnSwitched += this.OnSwitchWeapon;
            _attackComponent.OnAttack += this.OnRequestAttack;
        }

        private void OnDisable()
        {
            _animatorDispatcher.RemoveListener(MELEE_ANIM_EVENT, this.OnMeleeAttack);
            _animatorDispatcher.RemoveListener(RANGE_ANIM_EVENT, this.OnRangeAttack);

            _switchWeaponComponent.OnSwitched -= this.OnSwitchWeapon;
            _attackComponent.OnAttack -= this.OnRequestAttack;
        }

        private void OnMeleeAttack()
        {
            if (_currentWeaponComponent.Current is MeleeWeapon meleeWeapon)
            {
                meleeWeapon.Fire();
            }
        }

        private void OnRangeAttack()
        {
            if (_currentWeaponComponent.Current is RangeWeapon rangeWeapon)
            {
                rangeWeapon.Fire();
            }
        }

        private void OnSwitchWeapon(Weapon weapon)
        {
            if (weapon is MeleeWeapon)
            {
                _animator.Play(SWITCH_TO_MELEE, this.extraLayer, 0);
            }
            else if (weapon is RangeWeapon)
            {
                _animator.Play(SWITCH_TO_RANGE, this.extraLayer, 0);
            }
        }

        private void OnRequestAttack()
        {
            Weapon weapon = _currentWeaponComponent.Current;
            if (weapon == null)
            {
                return;
            }

            if (!weapon.CanFire())
            {
                return;
            }

            if (weapon is MeleeWeapon)
            {
                _animator.SetTrigger(MELEE_TRIGGER);
            }
            else if (weapon is RangeWeapon)
            {
                _animator.SetTrigger(RANGE_TRIGGER);
            }
        }
    }
}