using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    [CreateAssetMenu(
        fileName = "MoveSpeedEffect",
        menuName = "Engine/Effects/New MoveSpeedEffect"
    )]
    public sealed class MoveSpeedEffect : ScriptableEffect
    {
        [SerializeField]
        private AtomicValue<float> multiplier;

        public override void Apply(AtomicBehaviour obj)
        {
            if (obj.TryGet(MoveAPI.MoveSpeedExpression, out IAtomicExpression<float> moveSpeedExpression))
            {
                moveSpeedExpression.Append(this.multiplier);
            }
        }

        public override void Discard(AtomicBehaviour obj)
        {
            if (obj.TryGet(MoveAPI.MoveSpeedExpression, out IAtomicExpression<float> moveSpeedExpression))
            {
                moveSpeedExpression.Remove(this.multiplier);
            }
        }
    }
}