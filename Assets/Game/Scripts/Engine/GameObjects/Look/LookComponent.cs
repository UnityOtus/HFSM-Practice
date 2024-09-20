using UnityEngine;

namespace Game.Engine
{
    public sealed class LookComponent : MonoBehaviour
    {
        public float CurrentDirection
        {
            get => currentDirection;
            set => currentDirection = value;
        }

        private float currentDirection;

        private void FixedUpdate()
        {
            if (this.currentDirection == 0)
            {
                return;
            }

            float angle = this.currentDirection > 0 ? 0 : 180;
            this.transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}