using UnityEngine.Scripting.APIUpdating;

namespace Atomic.AI
{
    [MovedFrom(true, "Modules.AI", "Modules.AI.Gizmos", null)] 
    public interface IAIGizmos
    {
        void OnGizmos(IBlackboard blackboard);
    }
}