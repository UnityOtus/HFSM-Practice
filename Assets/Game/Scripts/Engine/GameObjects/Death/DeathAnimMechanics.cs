using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class DeathAnimMechanics : MonoBehaviour
    {
        private static readonly int DEATH_ANIM = Animator.StringToHash("Destroy");
        
        private Animator _animator;

        [SerializeField]
        private DeathComponent _dealthComponent;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _dealthComponent.OnDeath += this.OnDeath;
        }

        private void OnDisable()
        {
            _dealthComponent.OnDeath -= this.OnDeath;
        }

        private void OnDeath()
        {
            _animator.Play(DEATH_ANIM, -1, 0);
        }
    }
}