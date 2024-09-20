using UnityEngine.Scripting.APIUpdating;

namespace Atomic.AI
{
    [MovedFrom(true, "Modules.AI", "Modules.AI.StateMachine", null)] 
    public interface IState : IAIEnable, IAIUpdate, IAIDisable
    {
        public string Name { get; }

        void OnEnter(IBlackboard blackboard);
        void OnExit(IBlackboard blackboard);

        void IAIEnable.Enable(IBlackboard blackboard) => this.OnEnter(blackboard);
        void IAIDisable.Disable(IBlackboard blackboard) => this.OnExit(blackboard);
    }
}