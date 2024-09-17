using System;

namespace Modules.AI
{
    [Serializable]
    public sealed class IntInstaller : BlackboardInstaller<int>
    {
        public override void Install(IBlackboard blackboard)
        {
            blackboard.SetInt(this.key, this.value);
        }
    }
}