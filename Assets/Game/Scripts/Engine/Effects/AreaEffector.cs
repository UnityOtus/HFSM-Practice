using Atomic.Behaviours;
using UnityEngine;

namespace Game.Engine
{
    public sealed class AreaEffector : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEffect effect;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            var obj = col.GetComponentInParent<AtomicBehaviour>();
            
            if (obj != null)
            {
                this.effect.Apply(obj);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            var obj = col.GetComponentInParent<AtomicBehaviour>();

            if (obj != null)
            {
                this.effect.Discard(obj);
            }
        }
    }
}