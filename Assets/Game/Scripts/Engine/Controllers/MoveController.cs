using UnityEngine;

namespace Game.Engine
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;
        
        public void Update()
        {
            float moveDirection = 0;
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = 1;
            }

            if (_character != null && _character.TryGetComponent(out MoveComponent moveComponent))
            {
                moveComponent.CurrentDirection = moveDirection;
            }
        }
    }
}