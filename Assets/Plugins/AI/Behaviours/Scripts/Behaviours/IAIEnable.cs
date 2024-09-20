namespace Atomic.AI
{
    public interface IAIEnable : IAIBehaviour
    {
        void Enable(IBlackboard blackboard);
    }
}