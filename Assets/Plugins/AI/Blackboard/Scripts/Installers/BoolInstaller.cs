using System;
using Sirenix.OdinInspector;

namespace Modules.AI
{
    [Serializable, InlineProperty]
    public sealed class BoolInstaller : BlackboardInstaller<bool>
    {
        public override void Install(IBlackboard blackboard)
        {
            blackboard.SetBool(this.key, this.value);
        }
    }
}