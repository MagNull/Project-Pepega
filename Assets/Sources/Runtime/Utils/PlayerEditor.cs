﻿#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sources.Runtime.Player_Components;
using UnityEditor;
using UnityEngine;

namespace Sources.Runtime.Utils
{
    [CustomEditor(typeof(Player))]
    public class PlayerEditor : OdinEditor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Clear PlayerPrefs"))
            {
                PlayerPrefs.DeleteAll();
            }
            base.OnInspectorGUI();
        }
    }
}
#endif