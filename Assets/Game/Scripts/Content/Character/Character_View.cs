using System;
using Atomic.Objects;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [Serializable]
    public sealed class Character_View
    {
        [SerializeField]
        private Animator animator;

        [Get(CommonAPI.SpriteRenderer)]
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private MoveAnimMechanics moveMechanics;
        private JumpAnimMechanics jumpMechanics;
        private FlyAnimMechanics flyMechanics;

        public void Compose(Character_Core core)
        {
            this.moveMechanics = new MoveAnimMechanics(this.animator, core.isGroundMoving);
            this.jumpMechanics = new JumpAnimMechanics(this.animator, core.jumpComponent.JumpEvent);
            this.flyMechanics = new FlyAnimMechanics(this.animator, core.speedY);
        }

        public void OnEnable()
        {
            this.jumpMechanics.OnEnable();
        }

        public void OnDisable()
        {
            this.jumpMechanics.OnDisable();
        }

        public void Update()
        {
            this.moveMechanics.Update();
            this.flyMechanics.Update();
        }
    }
}