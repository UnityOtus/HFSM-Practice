using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class ColliderBufferInstaller : IBlackboardInstaller
    {
        [SerializeField]
        private int initialSize;
        
        public void Install(IBlackboard blackboard)
        {
            blackboard.SetColliderBuffer(new BufferData<Collider2D>
            {
                values = new Collider2D[this.initialSize],
                size = 0
            });
        }
    }
}