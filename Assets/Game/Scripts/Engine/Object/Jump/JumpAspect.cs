using System.Runtime.CompilerServices;
using Atomic.Behaviours;
using Atomic.Elements;

namespace Game.Engine
{
    public static class JumpAspect 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Compose(AtomicBehaviour target, float force, params IAtomicValue<bool>[] conditions)
        {
            target.AddType(ObjectType.Jumpable);
            target.AddProperty(JumpAPI.JumpEnabled, new AndExpression(conditions));
            target.AddProperty(JumpAPI.JumpForce, new AtomicValue<float>(force));
            target.AddProperty(JumpAPI.JumpAction, new JumpActionDynamic(target));
            target.AddProperty(JumpAPI.JumpEvent, new AtomicEvent());
        }

        public static void Dispose(AtomicBehaviour target)
        {
            target.RemoveType(ObjectType.Jumpable);
            target.RemoveProperty(JumpAPI.JumpEnabled);
            target.RemoveProperty(JumpAPI.JumpForce);
            target.RemoveProperty(JumpAPI.JumpAction);
            target.RemoveProperty(JumpAPI.JumpEvent);
        }
    }
}