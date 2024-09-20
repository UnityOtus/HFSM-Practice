using UnityEngine;

namespace Game.Engine
{
    public sealed class AttackController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.Attack();
            }    
        }

        private void Attack()
        {
            if (_character != null && _character.TryGetComponent(out AttackComponent attackComponent))
            {
                attackComponent.Attack();
            }
        }
    }
}