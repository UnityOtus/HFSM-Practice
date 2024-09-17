using System;
using Unity.Mathematics;

namespace Modules.AI
{
    [Serializable]
    public sealed class QuaternionInstaller : BlackboardInstaller<quaternion>
    {
        public override void Install(IBlackboard blackboard)
        {
            blackboard.SetQuaternion(this.key, this.value);
        }
    }
}