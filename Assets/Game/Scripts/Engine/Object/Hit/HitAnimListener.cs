using Atomic.Behaviours;
using Atomic.Elements;

namespace Game.Engine
{
    public sealed class HitAnimListener : IEnable, IDisable
    {
        private const string ATTACK_EVENT = "attack_hit";
        
        private readonly AnimatorDispatcher animator;
        private readonly IAtomicAction hitAction;

        public HitAnimListener(AnimatorDispatcher animator, IAtomicAction hitAction)
        {
            this.animator = animator;
            this.hitAction = hitAction;
        }

        public void Enable()
        {
            this.animator.AddListener(ATTACK_EVENT, hitAction.Invoke);
        }

        public void Disable()
        {
            this.animator.RemoveListener(ATTACK_EVENT, hitAction.Invoke);
        }
    }
}