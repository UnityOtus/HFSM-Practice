using System;
using UnityEngine;

namespace Modules.AI
{
    [Serializable]
    public sealed class TransformInstaller : BlackboardInstaller<Transform>
    {
        public override void Install(IBlackboard blackboard)
        {
            blackboard.SetObject(this.key, this.value);
        }
    }
}