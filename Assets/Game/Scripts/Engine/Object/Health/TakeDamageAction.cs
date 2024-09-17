using System;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace Game.Engine
{
    [Serializable]
    public class TakeDamageAction : IAtomicAction<int>
    {
        private HitPoints hitPoints;
        private IAtomicAction<int> damageEvent; 
        
        public void Compose(HitPoints hitPoints, IAtomicAction<int> damageEvent) 
        {
            this.hitPoints = hitPoints;
            this.damageEvent = damageEvent;
        }
        
        [Button]
        public void Invoke(int damage)
        {
            if (this.hitPoints.Current > 0)
            {
                this.hitPoints.Current -= damage;
                this.damageEvent?.Invoke(damage);
            }
        }
    }
}