using Atomic.Behaviours;
using Atomic.Elements;

namespace Game.Content
{
    public sealed class PirateLookMechanics : IFixedUpdate
    {
        private readonly IAtomicValue<float> moveDirection;
        private readonly IAtomicSetter<float> flipDirection;

        public PirateLookMechanics(IAtomicValue<float> moveDirection, IAtomicSetter<float> flipDirection)
        {
            this.moveDirection = moveDirection;
            this.flipDirection = flipDirection;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            var moveDirection = this.moveDirection.Value;
            if (moveDirection != 0)
            {
                this.flipDirection.Value = moveDirection;
            }
        }
    }
}