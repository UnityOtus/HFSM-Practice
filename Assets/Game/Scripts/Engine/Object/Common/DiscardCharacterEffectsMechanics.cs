using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    public sealed class DiscardCharacterEffectsMechanics
    {
        public void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.TryGetComponent(out IAtomicObject obj) && obj.Is(ObjectType.Character))
            {
                obj.Get<EffectManager>(CommonAPI.EffectManager).DiscardAllEffects();
            }
        }
    }
}