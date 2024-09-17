using UnityEngine.Scripting.APIUpdating;

namespace Modules.AI
{
    [MovedFrom(true, "Modules.AI.Elements", null, "IAIUpdate")] 
    public interface IUpdateBehaviour : IBehaviour
    {
        void OnUpdate(IBlackboard blackboard, float deltaTime);
    }
}