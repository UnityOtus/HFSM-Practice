using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Game.Engine
{
    public sealed class KillCharacterMechanics
    {
        public void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.TryGetComponent(out IAtomicObject obj) && obj.Is(ObjectType.Character))
            {
                obj.Get<IAtomicAction>(CommonAPI.DeathAction).Invoke();
            }
        }
    }
}