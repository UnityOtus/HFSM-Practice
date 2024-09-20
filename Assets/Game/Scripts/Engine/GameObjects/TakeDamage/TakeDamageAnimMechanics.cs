using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class TakeDamageAnimMechanics : MonoBehaviour
    {
        private static readonly int TAKE_DAMAGE_ANIM = Animator.StringToHash("TakeDamage");

        private Animator _animator;

        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private TakeDamageComponent _takeDamageComponent;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _takeDamageComponent.OnDamageTaken += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            _takeDamageComponent.OnDamageTaken -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int obj)
        {
            if (_healthComponent.IsAlive())
            {
                _animator.Play(TAKE_DAMAGE_ANIM, -1, -0);
            }
        }
    }
}