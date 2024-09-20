#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Atomic.AI
{
    [CreateAssetMenu(
        fileName = "BlackboardConfig",
        menuName = "Atomic/AI/New BlackboardConfig"
    )]
    internal sealed class BlackboardConfig : ScriptableObject
    {
        private static BlackboardConfig _config;

        internal static BlackboardConfig EditorInstance
        {
            get
            {
                if (_config != null)
                {
                    return _config;
                }
        
                string[] guids = AssetDatabase.FindAssets("t:" + nameof(BlackboardConfig));
                if (guids.Length == 0)
                {
                    return null;
                }

                string assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
                _config = AssetDatabase.LoadAssetAtPath<BlackboardConfig>(assetPath);
                return _config;
                //
                //
                // return AssetDatabase.LoadAssetAtPath<BlackboardConfig>(
                //     "Assets/Plugins/AI/Blackboards/Config/BlackboardConfig.asset");
            }
        }
        
        
        
        
        internal IReadOnlyList<Key> Keys
        {
            get => this.keys;
        }

        public string Namespace = "Atomic.AI";

        [SerializeField]
        public string directoryPath = "Assets/Plugins/AI/Blackboards/Scripts";
        
        [SerializeField]
        public string className = "BlackboardAPI";

        [FormerlySerializedAs("namespaces")]
        [SerializeField]
        public string[] imports;
        
        [Space]
        [SerializeField]
        private List<Key> keys = new();

        internal string NameOf(int id)
        {
            foreach (var key in this.keys)
            {
                if (key.id == id)
                {
                    return key.name;
                }
            }

            return "UNDEFINED";
        }

       


        private void Reset()
        {
            this.keys = new List<Key>
            {
                new()
                {
                    id = 0,
                    name = "UNDEFINED"
                }
            };
        }

        public bool HasDuplicateNames(out string name)
        {
            var count = this.keys.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (this.keys[i].name == this.keys[j].name)
                    {
                        name = this.keys[i].name;
                        return true;
                    }
                }
            }

            name = default;
            return false;
        }

        public bool HasDuplicateIds(out ushort id)
        {
            var count = this.keys.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (this.keys[i].id == this.keys[j].id)
                    {
                        id = this.keys[i].id;
                        return true;
                    }
                }
            }

            id = default;
            return false;
        }


        [Button]
        public void Compile()
        {
            BlackboardAPIGenerator.Generate(this);
        }

        [Serializable]
        public sealed class Key : IComparable<Key>
        {
            public ushort id;
            public string name;
            public string type;

            public int CompareTo(Key other)
            {
                return this.id.CompareTo(other.id);
            }
        }

        public void RemoveAt(int index)
        {
            this.keys.RemoveAt(index);
        }


        public void Sort()
        {
            this.keys.Sort();
        }

        // private void OnValidate()
        // {
        //     this.keys.Sort();
        // }
    
        public Key NewKey(string name, string type)
        {
            ushort id = this.GetFreeId();

            var key = new Key
            {
                id = id,
                name = name,
                type = type
            };
            this.keys.Add(key);
            return key;
        }

        public ushort GetFreeId()
        {
            var freeIds = new List<ushort>();

            for (ushort i = 1, count = (ushort) this.keys.Count; i <= count; i++)
            {
                freeIds.Add(i);
            }

            foreach (var key in this.keys)
            {
                freeIds.Remove(key.id);
            }

            return freeIds[0];
        }

        public bool HasKeyWithName(string keyName)
        {
            return this.keys.Any(key => key.name == keyName);
        }
    }
}
#endif