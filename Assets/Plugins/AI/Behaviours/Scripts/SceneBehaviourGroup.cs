using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper stoppable ConvertToAutoPropertyWithPrivateSetter
// ReSharper stoppable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace Atomic.AI
{
    [AddComponentMenu("Atomic/AI/AI Behaviour Group")]
    [DisallowMultipleComponent]
    public sealed class SceneBehaviourGroup : MonoBehaviour, ISerializationCallbackReceiver
    {
        [HideInPlayMode]
        [SerializeField]
        private SceneBlackboard blackboard;

        [SerializeReference, HideInPlayMode]
        private IAIBehaviour[] initialBehaviours = Array.Empty<IAIBehaviour>();

        private BehaviourGroup behaviourGroup;

        [FoldoutGroup("Debug")]
        [ShowInInspector, ReadOnly, HideInEditorMode]
        public bool IsStarted
        {
            get { return this.behaviourGroup != null && behaviourGroup.IsStarted; }
        }

        [FoldoutGroup("Debug")]
        [ShowInInspector, ReadOnly, HideInEditorMode]
        public IReadOnlyList<IAIBehaviour> AllBehaviours
        {
            get { return this.behaviourGroup != null ? behaviourGroup.AllBehaviours : Array.Empty<IAIBehaviour>(); }
        }

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public void OnStart()
        {
            this.behaviourGroup.Enable();
        }

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public void OnUpdate(float deltaTime)
        {
            this.behaviourGroup.OnUpdate(deltaTime);
        }

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public void OnStop()
        {
            this.behaviourGroup.Disable();
        }

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public bool AddBehaviour(IAIBehaviour target)
        {
            return behaviourGroup.AddBehaviour(target);
        }

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public bool DelBehaviour(IAIBehaviour target)
        {
            return behaviourGroup.DelBehaviour(target);
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.behaviourGroup = new BehaviourGroup(this.blackboard);

            for (int i = 0, count = this.initialBehaviours.Length; i < count; i++)
            {
                this.behaviourGroup.AddBehaviour(this.initialBehaviours[i]);
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        #region Unity

        [PropertyOrder(-100)]
        [SerializeField]
        private bool controlState = true;

        [PropertyOrder(-99)]
        [ShowIf(nameof(controlState))]
        [SerializeField]
        private UpdateMode updateMode = UpdateMode.UPDATE;

        private void Awake()
        {
            if (!this.controlState)
            {
                this.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (this.controlState)
            {
                this.behaviourGroup.Enable();
            }
        }

        private void OnDisable()
        {
            if (this.controlState)
            {
                this.behaviourGroup.Disable();
            }
        }

        private void Update()
        {
            if (this.controlState && this.updateMode == UpdateMode.UPDATE)
            {
                this.behaviourGroup.OnUpdate(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (this.controlState && this.updateMode == UpdateMode.FIXED_UPDATE)
            {
                this.behaviourGroup.OnUpdate(Time.fixedDeltaTime);
            }
        }

        #endregion
    }
}