using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [RequireComponent(typeof(MoveComponent), typeof(DealDamageComponent))]
    public sealed class Bullet : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private DealDamageComponent _damageComponent;

        [SerializeField]
        private float lifetime = 3;

        private void Awake()
        {
            _moveComponent = this.GetComponent<MoveComponent>();
            _damageComponent = this.GetComponent<DealDamageComponent>();
        }
        
        private void Start()
        {
            _moveComponent.CurrentDirection = Mathf.Sign(this.transform.right.x);
            Destroy(this.gameObject, this.lifetime);
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (_damageComponent.DealDamage(collider.gameObject))
            {
                Destroy(this.gameObject);
            }
        }
    }
}