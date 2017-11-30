using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace KBehave
{
    [CustomEditor(typeof(Debugger))]
    public class DebuggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Behave Debugger", EditorStyles.centeredGreyMiniLabel);

            if (GUILayout.Button("Open Debugger"))
            {
                DebuggerWindow.selectedDebugger = ((Debugger)target);
                DebuggerWindow.selectedObject = DebuggerWindow.selectedDebugger.transform;
                DebuggerWindow.ShowWindow();
            }
        }
    }
}