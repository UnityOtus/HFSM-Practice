#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Atomic.AI
{
    [MovedFrom(true, "Modules.AI", "Modules.AI.Gizmos", null)] 
    [Serializable]
    public sealed class WireSphereGizmos : IAIGizmos
    {
        [BlackboardKey]
        [SerializeField]
        private int centerKey;

        [BlackboardKey]
        [SerializeField]
        private int radiusKey;

        [SerializeField]
        private Color color = Color.magenta;
        
        public void OnGizmos(IBlackboard blackboard)
        {
            if (!blackboard.TryGetObject(this.centerKey, out Transform center) ||
                !blackboard.TryGetFloat(this.radiusKey, out float boxSize))
            {
                return;
            }

            Color prevColor = Handles.color;
            Gizmos.color = this.color;
            Gizmos.DrawWireSphere(center.position, boxSize);
            Gizmos.color = prevColor;
        }
    }
}
#endif