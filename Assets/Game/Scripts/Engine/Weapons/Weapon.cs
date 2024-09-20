using UnityEngine;

namespace Game.Engine
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract bool CanFire();
        public abstract void Fire();
    }
}