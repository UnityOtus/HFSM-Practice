using System;

namespace Game.Engine.AI
{
    [Serializable]
    public struct AttackData
    {
        public bool enabled;
        public float minDistance;

        public float MinDistanceSq
        {
            get { return this.minDistance * this.minDistance; }
        }
    }
}