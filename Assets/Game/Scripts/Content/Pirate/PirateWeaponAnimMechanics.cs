using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(AnimatorDispatcher))]
    public sealed class PirateWeaponAnimMechanics : MonoBehaviour
    {
        private const string ATTACK_EVENT = "attack_hit";

        private AnimatorDispatcher _dispatcher;

        [SerializeField]
        private CurrentWeaponComponent _weaponComponent;
        
        private void Awake()
        {
            _dispatcher = this.GetComponent<AnimatorDispatcher>();
        }

        private void OnEnable()
        {
            _dispatcher.AddListener(ATTACK_EVENT, _weaponComponent.Fire);
        }

        private void OnDisable()
        {
            _dispatcher.RemoveListener(ATTACK_EVENT, _weaponComponent.Fire);
        }
    }
}