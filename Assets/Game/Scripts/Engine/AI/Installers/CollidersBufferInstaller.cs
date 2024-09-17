using System;
using AIModule;
using Modules.AI;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public sealed class CollidersBufferInstaller : IBlackboardInstaller
    {
        [SerializeField]
        private int initialSize;
        
        public void Install(IBlackboard blackboard)
        {
            blackboard.SetStruct(BlackboardAPI.CollidersBuffer, new BufferData<Collider2D>
            {
                values = new Collider2D[this.initialSize],
                size = 0
            });
        }
    }
}