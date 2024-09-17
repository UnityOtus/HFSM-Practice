using System;

namespace Modules.AI
{
    [Serializable]
    public sealed class FloatInstaller : BlackboardInstaller<float>
    {
        public override void Install(IBlackboard blackboard)
        {
            blackboard.SetFloat(this.key, this.value);
        }
    }
}