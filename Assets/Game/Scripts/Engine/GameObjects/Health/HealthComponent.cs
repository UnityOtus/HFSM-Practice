using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public event Action<int> OnChanged;
        
        public int Current
        {
            get { return hitPoints; }
            set
            {
                value = Mathf.Clamp(value, 0, maxHitPoints);
                hitPoints = value;
                OnChanged?.Invoke(value);
            }
        }

        public int Max
        {
            get { return maxHitPoints; }
            set
            {
                value = Math.Max(1, value);
                if (hitPoints > value)
                    hitPoints = value;

                maxHitPoints = value;
            }
        }
        
        [SerializeField]
        private int maxHitPoints;

        [SerializeField]
        private int hitPoints;

        public bool IsAlive()
        {
            return this.Current > 0;
        }

        public bool IsNotAlive()
        {
            return this.Current <= 0;
        }
    }
}