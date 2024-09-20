using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class CurrentWeaponComponent : MonoBehaviour
    {
        public event Action<Weapon> OnChanged;

        public Weapon Current
        {
            get => this.currentWeapon;
            set
            {
                if (this.currentWeapon != value)
                {
                    this.currentWeapon = value;
                    this.OnChanged?.Invoke(value);
                }
            }
        }

        [SerializeField]
        private Weapon currentWeapon;

        public void Fire()
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Fire();
            }
        }
    }
}