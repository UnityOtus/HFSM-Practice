using Atomic.Elements;

namespace Game.Engine
{
    public sealed class DeathMechanics
    {
        private readonly HitPoints hitPoints;
        private readonly IAtomicEvent deathEvent;

        public DeathMechanics(HitPoints hitPoints, IAtomicEvent deathEvent)
        {
            this.hitPoints = hitPoints;
            this.deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            hitPoints.OnChanged += OnHitPointsChanged;
        }

        public void OnDisable()
        {
            hitPoints.OnChanged -= OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int hp)
        {
            if (hp <= 0)
                deathEvent?.Invoke();
        }
    }
}