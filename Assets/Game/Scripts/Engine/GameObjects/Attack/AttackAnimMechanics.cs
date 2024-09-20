using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class AttackAnimMechanics : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        private Animator _animator;
        private AttackComponent _attackComponent;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
            _attackComponent = this.GetComponent<AttackComponent>();
        }

        private void OnEnable()
        {
            _attackComponent.OnAttack += this.OnAttack;
        }

        private void OnDisable()
        {
            _attackComponent.OnAttack -= this.OnAttack;
        }

        private void OnAttack()
        {
            _animator.SetTrigger(Attack);
        }
    }
}