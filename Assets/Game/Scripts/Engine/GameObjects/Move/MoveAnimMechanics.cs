using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class MoveAnimMechanics : MonoBehaviour
    {
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");

        private Animator _animator;

        [SerializeField]
        private MoveComponent _moveComponent;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
        }

        public void LateUpdate()
        {
            this._animator.SetBool(IsMovingHash, _moveComponent.IsMoving());
        }
    }
}