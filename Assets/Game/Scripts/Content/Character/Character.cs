using Atomic.Behaviours;
using Atomic.Objects;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [Is(ObjectType.Character)]
    public sealed class Character : AtomicBehaviour
    {
        [SerializeField, Section]
        private Character_Core core;

        [SerializeField, Section]
        private Character_View view;

        // [SerializeField, Section]
        // private Character_AI ai;

        private void Awake()
        {
            this.Compose();
            this.core.Compose(this);
            this.view.Compose(this.core);
            // this.ai.Compose(this);
        }

        private void OnEnable()
        {
            this.Enable();
            this.view.OnEnable();
        }

        private void OnDisable()
        {
            this.Disable();
            this.view.OnDisable();
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            this.OnFixedUpdate(deltaTime);
            this.core.OnFixedUpdate(deltaTime);
            // this.ai.OnFixedUpdate(deltaTime);
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
            this.view.Update();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            this.core.OnTriggerEnter2D(col);
        }

        private void OnDrawGizmos()
        {
            this.core.OnDrawGizmos();
        }

        private void OnDestroy()
        {
            this.core.Dispose();
        }
    }
}