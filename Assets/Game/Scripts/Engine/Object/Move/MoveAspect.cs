using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Extensions;

namespace Game.Engine
{
    public static class MoveAspect
    {
        public static void Compose(AtomicBehaviour entity, float speed = 0)
        {
            var moveDirection = new AtomicVariable<float>();
            var moveEnabled = new AndExpression();
            
            entity.AddProperty(MoveAPI.MoveSpeed, new AtomicValue<float>(speed));
            entity.AddProperty(MoveAPI.MoveDirection, moveDirection);
            entity.AddProperty(MoveAPI.MoveEnabled, moveEnabled);
            entity.AddProperty(MoveAPI.IsMoving, new AtomicFunction<bool>(
                () => moveDirection.Value != 0 && moveEnabled.Invoke()));
            
            entity.AddLogic(new MovementMechanicsDynamic(entity));
        }

        public static void Dispose(AtomicBehaviour entity)
        {
            entity.RemoveProperty(MoveAPI.MoveSpeed);
            entity.RemoveProperty(MoveAPI.MoveDirection);
            entity.RemoveProperty(MoveAPI.MoveEnabled);
            entity.RemoveProperty(MoveAPI.IsMoving);
            
            entity.RemoveLogic<MovementMechanicsDynamic>();
        }
    }
}