using UnityEngine;

namespace Game.Engine
{
    public sealed class SwitchWeaponController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                this.SwitchWeapon();
            }
        }

        private void SwitchWeapon()
        {
            if (_character != null && _character.TryGetComponent(out SwitchWeaponComponent switchComponent))
            {
                switchComponent.SwitchWeapon();
            }
        }
    }
}