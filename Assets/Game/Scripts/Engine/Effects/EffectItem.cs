using Atomic.Behaviours;
using UnityEngine;

namespace Game.Engine
{
    public sealed class EffectItem : MonoBehaviour
    {
        // [SerializeField]
        // private ScriptableEffect effect;

        // [SerializeField]
        // private CompositeEffect effectPrefab;

        [SerializeReference]
        private IEffect effect;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            var obj = col.GetComponentInParent<AtomicBehaviour>();

            if (obj != null && obj.TryGet(CommonAPI.EffectManager, out EffectManager effectManager))
            {
                // Transform objTransform = obj.transform;
                // IEffect effect = Instantiate(this.effectPrefab, objTransform.position, objTransform.rotation, objTransform);
                effectManager.ApplyEffect(this.effect);
                Destroy(this.gameObject);
            }
        }
    }
}