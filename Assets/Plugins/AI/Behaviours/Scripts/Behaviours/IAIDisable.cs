namespace Atomic.AI
{
    public interface IAIDisable : IAIBehaviour
    {
        void Disable(IBlackboard blackboard);
    }
}