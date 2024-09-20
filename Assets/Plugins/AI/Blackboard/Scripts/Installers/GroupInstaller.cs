using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Atomic.AI
{
    [MovedFrom(true, "Modules.AI", "Modules.AI.Blackboard")]
    [Serializable]
    public class GroupInstaller : IBlackboardInstaller
    {
#if UNITY_EDITOR
        [GUIColor(1f, 0.92156863f, 0.015686275f)]
        [SerializeField]
        private string name;
#endif

        [SerializeReference]
        private IBlackboardInstaller[] installers = default;
        
        public virtual void Install(IBlackboard blackboard)
        {
            if (this.installers != null)
            {
                for (int i = 0, count = this.installers.Length; i < count; i++)
                {
                    this.installers[i].Install(blackboard);
                }
            }
        }
    }
}