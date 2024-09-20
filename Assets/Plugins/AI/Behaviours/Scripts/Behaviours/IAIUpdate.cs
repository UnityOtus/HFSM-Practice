namespace Atomic.AI
{
    public interface IAIUpdate : IAIBehaviour
    {
        void OnUpdate(IBlackboard blackboard, float deltaTime);
    }
}