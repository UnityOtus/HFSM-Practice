using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Atomic.AI
{
    [MovedFrom(true, "Modules.AI", "Modules.AI.StateMachine")]
    [Serializable]
    public class State : IState
    {
        public virtual string Name => this.name;

        [GUIColor(1f, 0.92156863f, 0.015686275f)]
        [SerializeField]
        private string name = "State Name";

        [Header("Behaviours")]
        [SerializeReference]
        private IAIBehaviour[] behaviours = default;

        [Header("Actions")]
        [SerializeReference]
        private IBlackboardAction[] enterActions = default;

        [SerializeReference]
        private IBlackboardAction[] exitActions = default;

        public virtual void OnEnter(IBlackboard blackboard)
        {
            this.StartBehaviours(blackboard);
            this.StartActions(blackboard);
        }

        private void StartBehaviours(IBlackboard blackboard)
        {
            if (this.behaviours == null)
            {
                return;
            }
            
            for (int i = 0, count = this.behaviours.Length; i < count; i++)
            {
                if (this.behaviours[i] is IAIEnable behaviour)
                {
                    behaviour.Enable(blackboard);
                }
            }
        }

        private void StartActions(IBlackboard blackboard)
        {
            if (this.enterActions == null)
            {
                return;
            }

            int count = this.enterActions.Length;
            if (count == 0)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                var enable = this.enterActions[i];
                enable.Invoke(blackboard);
            }
        }

        public virtual void OnUpdate(IBlackboard blackboard, float deltaTime)
        {
            this.UpdateBehaviours(blackboard, deltaTime);
        }

        private void UpdateBehaviours(IBlackboard blackboard, float deltaTime)
        {
            if (this.behaviours == null)
            {
                return;
            }

            for (int i = 0, count = this.behaviours.Length; i < count; i++)
            {
                if (this.behaviours[i] is IAIUpdate updateBehaviour)
                {
                    updateBehaviour.OnUpdate(blackboard, deltaTime);
                }
            }
        }

        public virtual void OnExit(IBlackboard blackboard)
        {
            this.StopBehaviours(blackboard);
            this.StopActions(blackboard);
        }

        private void StopActions(IBlackboard blackboard)
        {
            if (this.exitActions == null)
            {
                return;
            }

            int count = this.exitActions.Length;
            if (count == 0)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                var disable = this.exitActions[i];
                disable.Invoke(blackboard);
            }
        }

        private void StopBehaviours(IBlackboard blackboard)
        {
            if (this.behaviours == null)
            {
                return;
            }

            for (int i = 0, count = this.behaviours.Length; i < count; i++)
            {
                if (this.behaviours[i] is IAIDisable behaviour)
                {
                    behaviour.Disable(blackboard);
                }
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}