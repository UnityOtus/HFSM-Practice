using System;
using UnityEngine;

namespace Modules.AI
{
    [Serializable]
    public sealed class Float2Installer : BlackboardInstaller<Vector2>
    {
        public override void Install(IBlackboard blackboard)
        {
            blackboard.SetFloat2(this.key, this.value);
        }
    }
}