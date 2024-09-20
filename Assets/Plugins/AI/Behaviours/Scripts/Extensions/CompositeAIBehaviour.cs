using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
// ReSharper disable NotAccessedField.Local

namespace Atomic.AI
{
    [MovedFrom(true, "Modules.AI", "Modules.AI.BehaviourSet", "CompositeBehaviour")]
    [Serializable]
    public sealed class CompositeAIBehaviour :
        IAIEnable,
        IAIDisable,
        IAIUpdate,
        ISerializationCallbackReceiver
    {
        #if UNITY_EDITOR

        [GUIColor(1f, 0.92156863f, 0.015686275f)]
        [SerializeField, HideLabel]
        private string name;
        
        #endif
        
        [SerializeReference]
        private List<IAIBehaviour> behaviours = default;

        private List<IAIUpdate> updateBehaviours = new();

        public void Enable(IBlackboard blackboard)
        {
            if (this.behaviours != null)
            {
                for (int i = 0, count = this.behaviours.Count; i < count; i++)
                {
                    if (this.behaviours[i] is IAIEnable behaviour)
                    {
                        behaviour.Enable(blackboard);
                    }
                }
            }
        }

        public void Disable(IBlackboard blackboard)
        {
            if (this.behaviours != null)
            {
                for (int i = 0, count = this.behaviours.Count; i < count; i++)
                {
                    if (this.behaviours[i] is IAIDisable behaviour)
                    {
                        behaviour.Disable(blackboard);
                    }
                }
            }
        }

        public void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            if (this.updateBehaviours.Count == 0)
            {
                return;
            }

            for (int i = 0, count = this.updateBehaviours.Count; i < count; i++)
            {
                IAIUpdate logic = this.updateBehaviours[i];
                logic.OnUpdate(blackboard, deltaTime);
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.updateBehaviours = new List<IAIUpdate>();
            
            if (this.behaviours == null)
            {
                return;
            }
            
            for (int i = 0, count = this.behaviours.Count; i < count; i++)
            {
                if (this.behaviours[i] is IAIUpdate updateBehaviour)
                {
                    this.updateBehaviours.Add(updateBehaviour);
                }
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }
    }
}