using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper stoppable ConvertToAutoPropertyWithPrivateSetter
// ReSharper stoppable FieldCanBeMadeReadOnly.Local
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace Modules.AI
{
    [AddComponentMenu("Modules/AI/AI Behaviour Group")]
    [DisallowMultipleComponent]
    public sealed class SceneBehaviourGroup : MonoBehaviour, ISerializationCallbackReceiver
    {
        [HideInPlayMode]
        [SerializeField]
        private SceneBlackboard blackboard;

        [SerializeReference, HideInPlayMode]
        private IBehaviour[] initialBehaviours = Array.Empty<IBehaviour>();

        private BehaviourGroup behaviourGroup;

        [FoldoutGroup("Debug")]
        [ShowInInspector, ReadOnly, HideInEditorMode]
        public bool IsStarted => behaviourGroup?.IsStarted ?? false;

        [FoldoutGroup("Debug")]
        [ShowInInspector, ReadOnly, HideInEditorMode]
        public IReadOnlyList<IBehaviour> AllBehaviours => behaviourGroup?.AllBehaviours;

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public void OnStart()
        {
            this.behaviourGroup.OnStart();
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
            this.behaviourGroup.OnStop();
        }

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public bool AddBehaviour(IBehaviour target)
        {
            return behaviourGroup.AddBehaviour(target);
        }

        [FoldoutGroup("Debug")]
        [Button, HideInEditorMode]
        public bool DelBehaviour(IBehaviour target)
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

        private enum UpdateMode
        {
            UPDATE = 0,
            FIXED_UPDATE = 1,
            MANUAL = 2,
        }
        
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
                this.behaviourGroup.OnStart();
            }
        }
        
        private void OnDisable()
        {
            if (this.controlState)
            {
                this.behaviourGroup.OnStop();
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


// #region Debug
//
// #if UNITY_EDITOR && ODIN_INSPECTOR
//         
//         ///Logics
//         private static readonly List<BehaviourElement> _behaviourElementsCache = new();
//
//         [InlineProperty]
//         private struct BehaviourElement
//         {
//             [ShowInInspector, ReadOnly]
//             public string name;
//             internal readonly IBehaviour value;
//
//             public BehaviourElement(string name, IBehaviour value)
//             {
//                 this.name = name;
//                 this.value = value;
//             }
//         }
//
//         [FoldoutGroup("Debug")]
//         [LabelText("Behavuiours")]
//         [ShowInInspector, PropertyOrder(100)]
//         [ListDrawerSettings(
//             CustomRemoveElementFunction = nameof(RemoveLogicElement),
//             CustomRemoveIndexFunction = nameof(RemoveLogicElementAt),
//             HideAddButton = true
//         )]
//         private List<BehaviourElement> BehaviourElements
//         {
//             get
//             {
//                 _behaviourElementsCache.Clear();
//
//                 IReadOnlyList<IBehaviour> logics = this.behaviourGroup?.AllBehaviours;
//                 if (logics == null)
//                 {
//                     return _behaviourElementsCache;
//                 }
//
//                 for (int i = 0, count = logics.Count; i < count; i++)
//                 {
//                     IBehaviour logic = logics[i];
//                     string name = logic.GetType().Name;
//                     _behaviourElementsCache.Add(new BehaviourElement(name, logic));
//                 }
//
//                 return _behaviourElementsCache;
//             }
//             set
//             {
//                 /** noting... **/
//             }
//         }
//
//         private void RemoveLogicElement(BehaviourElement behaviourElement)
//         {
//             if (behaviourGroup != null) this.DelBehaviour(behaviourElement.value);
//         }
//
//         private void RemoveLogicElementAt(int index)
//         {
//             if (behaviourGroup != null) this.DelBehaviour(AllBehaviours[index]);
//         }
// #endif
//         #endregion