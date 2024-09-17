using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    [CreateAssetMenu(
        fileName = "JumpForceEffect",
        menuName = "Engine/Effects/New JumpForceEffect"
    )]
    public sealed class JumpForceEffect : ScriptableEffect
    {
        [SerializeField]
        private AtomicValue<float> range;

        public override void Apply(AtomicBehaviour obj)
        {
            if (obj.TryGet(JumpAPI.JumpForceExpression, out IAtomicExpression<float> forceExpression))
            {
                forceExpression.Append(this.range);
            }
        }

        public override void Discard(AtomicBehaviour obj)
        {
            if (obj.TryGet(JumpAPI.JumpForceExpression, out IAtomicExpression<float> forceExpression))
            {
                forceExpression.Remove(this.range);
            }
        }
    }
}