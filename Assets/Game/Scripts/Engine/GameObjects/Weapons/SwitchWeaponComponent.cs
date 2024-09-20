using System;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(WeaponInventoryComponent), typeof(CurrentWeaponComponent))]
    public sealed class SwitchWeaponComponent : MonoBehaviour
    {
        public event Action<Weapon> OnSwitched;
        
        private WeaponInventoryComponent _weaponInventory;
        private CurrentWeaponComponent _weaponComponent;

        private void Awake()
        {
            _weaponInventory = this.GetComponent<WeaponInventoryComponent>();
            _weaponComponent = this.GetComponent<CurrentWeaponComponent>();
        }

        [SerializeField]
        private Timer switchWeaponTimer;
        
        public void SwitchWeapon()
        {
            Weapon nextWeapon = _weaponInventory.GetNextWeapon(_weaponComponent.Current);
                
            _weaponComponent.Current = nextWeapon;
            this.OnSwitched?.Invoke(nextWeapon);
            this.switchWeaponTimer.Reset();
        }
        
        public bool IsNotSwitching()
        {
            return this.switchWeaponTimer.IsEnded();
        }

        private void FixedUpdate()
        {
            this.switchWeaponTimer.Tick(Time.fixedDeltaTime);
        }
    }
}