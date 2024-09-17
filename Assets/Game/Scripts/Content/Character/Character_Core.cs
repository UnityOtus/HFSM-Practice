using System;
using Atomic.Behaviours;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [Serializable]
    public sealed class Character_Core : IFixedUpdate, IDisposable
    {
        [Get(CommonAPI.Transform)]
        public Transform transform;

        [Get(CommonAPI.Rigidbody)]
        public Rigidbody2D rigidbody;

        [SerializeField]
        public GameObject gameObject;

        [Get(CommonAPI.CollectCoinEvent)]
        public AtomicEvent collectCoinEvent;

        public AtomicVariable<bool> isAlive = new(true);

        public AtomicFunction<bool> isGroundMoving;

        public AtomicFunction<float> speedY;
        
        [Section]
        public MoveComponent moveComponent;

        [Section]
        public JumpComponent jumpComponent;

        [Section]
        public GroundedComponent groundedComponent;
        
        private CollectCoinMechanics collectCoinMechanics;

        [Get(CommonAPI.DeathAction)]
        [SerializeField]
        private AtomicAction deathAction;

        [Get(CommonAPI.EffectManager)]
        [SerializeField]
        private EffectManager effectManager;

        public void Compose(AtomicBehaviour character)
        {
            this.moveComponent.Let(it =>
            {
                it.Compose();
                it.MoveEnabled.Append(this.isAlive);
            });
            
            this.jumpComponent.Let(it =>
            {
                it.Compose();
                it.JumpEnabled.Append(this.isAlive);
                it.JumpEnabled.Append(this.groundedComponent.IsGrounded);
            });

            this.groundedComponent.Compose();
            
            this.deathAction.Compose(() =>
            {
                this.isAlive.Value = false;
                this.gameObject.SetActive(false);
            });

            this.collectCoinMechanics = new CollectCoinMechanics(this.collectCoinEvent);


            this.isGroundMoving.Compose(() => this.moveComponent.IsMoving.Value &&
                                              this.groundedComponent.IsGrounded.Value);

            this.speedY.Compose(() => this.rigidbody.velocity.y);

            this.effectManager.Compose(character);
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            this.collectCoinMechanics.OnTriggerEnter2D(col);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            this.moveComponent.OnFixedUpdate(deltaTime);
            this.groundedComponent.OnFixedUpdate(deltaTime);
        }

        public void OnDrawGizmos()
        {
            this.groundedComponent.OnDrawGizmos();
        }

        public void Dispose()
        {
            this.isAlive?.Dispose();
            this.moveComponent?.Dispose();
            this.collectCoinEvent?.Dispose();
        }
    }
}