#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.AI
{
    [CustomEditor(typeof(SceneBlackboard))]
    public sealed class BlackboardEditor : OdinEditor
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            SceneBlackboard._nameFunc = BlackboardConfig.EditorInstance.NameOf;
        }

        //
        // private SceneBlackboard blackboard;
        // private BlackboardConfig blackboardConfig;
        //
        // private void Awake()
        // {
        //     this.blackboard = (SceneBlackboard) this.target;
        //     this.blackboardConfig = BlackboardConfig.EditorInstance;
        // }
        //
        //
        //
        // public override void OnInspectorGUI()
        // {
        //     base.OnInspectorGUI();
        //
        //     if (EditorApplication.isPlaying)
        //     {
        //         EditorGUILayout.Space(8);
        //         SirenixEditorGUI.DrawThickHorizontalSeparator();
        //         this.DrawBlackboardState();
        //     }
        // }
        //
        // private void DrawBlackboardState()
        // {
        //     GUI.enabled = false;
        //
        //     var variables = new Dictionary<string, object>();
        //
        //     //Можно отрисовывать сразу значения!!!
        //     foreach ((int key, bool value) in this.blackboard.BoolValues)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = value;
        //     }
        //
        //     foreach ((int key, int value) in this.blackboard.IntValues)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = value;
        //     }
        //
        //     foreach ((int key, float value) in this.blackboard.FloatValues)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = value;
        //     }
        //
        //     foreach ((int key, float2 value) in this.blackboard.Float2Values)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = value;
        //     }
        //
        //     foreach ((int key, float3 value) in this.blackboard.Float3Values)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = value;
        //     }
        //
        //     foreach ((int key, quaternion value) in this.blackboard.QuaternionValues)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = value;
        //     }
        //     
        //     foreach ((int key, object value) in this.blackboard.ObjectValues)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = value;
        //     }
        //     
        //     foreach ((int key, IPtr ptr) in this.blackboard.StructValues)
        //     {
        //         string name = this.blackboardConfig.NameOf(key);
        //         variables[name] = ptr.Value;
        //     }
        //     
        //     foreach (var variable in variables)
        //     {
        //         this.DrawVariable(variable);
        //     }
        //
        //     GUI.enabled = true;
        // }
        //
        // private void DrawVariable(KeyValuePair<string, object> variable)
        // {
        //     (string name, object value) = variable;
        //
        //     if (value is int intValue)
        //     {
        //         EditorGUILayout.IntField(name, intValue);
        //     }
        //     else if (value is float floatValue)
        //     {
        //         EditorGUILayout.FloatField(name, floatValue);
        //     }
        //     else if (value is bool booleValue)
        //     {
        //         EditorGUILayout.Toggle(name, booleValue);
        //     }
        //     else if (value is string stringValue)
        //     {
        //         EditorGUILayout.TextField(name, stringValue);
        //     }
        //     else if (value is Object unityObject)
        //     {
        //         EditorGUILayout.ObjectField(name, unityObject, typeof(Object), allowSceneObjects: true);
        //     }
        //     
        //     
        //     
        //     // else if (value is IEnumerable enumerable)
        //     // {
        //     //     EditorGUI.indentLevel++;
        //     //     foreach (var e in enumerable)
        //     //     {
        //     //         
        //     //     }
        //     //     EditorGUI.indentLevel--;
        //     // }
        //
        //
        //     else if (value is float2 vector2)
        //     {
        //         EditorGUILayout.Vector2Field(name, vector2);
        //     }
        //     else if (value is float3 vector3)
        //     {
        //         EditorGUILayout.Vector3Field(name, vector3);
        //     }
        //     else if (value is quaternion quaternion)
        //     {
        //         Quaternion q = quaternion;
        //         EditorGUILayout.Vector3Field(name, q.eulerAngles);
        //     }
        //     else if (value is Enum enumValue)
        //     {
        //         EditorGUILayout.EnumPopup(enumValue);
        //     }
        //     else
        //     {
        //         EditorGUILayout.TextField(name, value != null ? value.ToString() : "null");
        //     }
        // }
    }
}
#endif