using System;
using Unity.Mathematics;

namespace Modules.AI
{
    [Serializable]
    public sealed class Float3Installer : BlackboardInstaller<float3>
    {
        public override void Install(IBlackboard blackboard)
        {
            blackboard.SetFloat3(this.key, this.value);
        }
    }
}