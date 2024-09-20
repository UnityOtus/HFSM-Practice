using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class Dummy : MonoBehaviour
    {
        [SerializeField]
        private DeathComponent _deathComponent;
        
        [SerializeField]
        private Collider2D _collider;
        
        private void OnEnable()
        {
            _deathComponent.OnDeath += this.OnDeath;
        }

        private void OnDisable()
        {
            _deathComponent.OnDeath -= this.OnDeath;
        }

        private void OnDeath()
        {
            _collider.enabled = false;
        }
    }
}