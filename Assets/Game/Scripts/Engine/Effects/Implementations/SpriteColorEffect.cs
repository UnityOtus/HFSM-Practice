using Atomic.Behaviours;
using UnityEngine;

namespace Game.Engine
{
    [CreateAssetMenu(
        fileName = "SpriteColorEffect",
        menuName = "Engine/Effects/New SpriteColorEffect"
    )]
    public sealed class SpriteColorEffect : ScriptableEffect
    {
        [SerializeField]
        private Color color;

        public override void Apply(AtomicBehaviour obj)
        {
            obj.Get<SpriteRenderer>(CommonAPI.SpriteRenderer).color = this.color;
        }

        public override void Discard(AtomicBehaviour obj)
        {
            obj.Get<SpriteRenderer>(CommonAPI.SpriteRenderer).color = Color.white;
        }
    }
}