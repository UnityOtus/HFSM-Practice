using System;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public struct SensorData
    {
        public Transform center;
        public float radius;
        public LayerMask layerMask;
    }
}