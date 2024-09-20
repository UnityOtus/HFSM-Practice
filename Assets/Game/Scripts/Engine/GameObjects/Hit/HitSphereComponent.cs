using System;
using UnityEditor;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class HitSphereComponent : MonoBehaviour
    {
        private static readonly Collider2D[] buffer = new Collider2D[32];

        [SerializeField]
        private Transform hitCenter;

        [SerializeField]
        private float hitRadius;
        
        [SerializeField]
        private LayerMask layerMask;

        public bool Hit(Func<GameObject, bool> action)
        {
            var size = Physics2D.OverlapCircleNonAlloc(this.hitCenter.position, hitRadius, buffer, this.layerMask);

            for (int i = 0; i < size; i++)
            {
                var collider = buffer[i];
                if (action.Invoke(collider.gameObject))
                {
                    return true;
                }
            }

            return false;
        }
        
        private void OnDrawGizmos()
        {
            if (this.hitCenter != null)
            {
                Handles.color = Color.red;
                Handles.DrawWireDisc(this.hitCenter.position, Vector3.forward, this.hitRadius);
            }
        }
    }
}