using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class WeaponInventoryComponent : MonoBehaviour
    {
        [SerializeField]
        private Weapon[] weapons;

        public Weapon GetNextWeapon(Weapon weapon)
        {
            if (weapon == null)
            {
                return this.weapons[0];
            }
            
            int index = Array.IndexOf(this.weapons, weapon);
            if (index == -1)
            {
                return this.weapons[0];
            }

            index = (index + 1) % this.weapons.Length;
            return this.weapons[index];
        }
        
        public T FindWeapon<T>() where T : Weapon
        {
            for (int i = 0, count = this.weapons.Length; i < count; i++)
            {
                Weapon weapon = this.weapons[i];
                if (weapon is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Weapon of type {typeof(T).Name} is not found!");
        }
    }
}