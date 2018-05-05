using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DunGen.Editor
{
    [CustomEditor(typeof(LocalPropSet))]
    public class LocalPropSetInspector : UnityEditor.Editor
    {
        private readonly List<bool> showWeights = new List<bool>();


        private void OnEnable()
        {
            for (int i = 0; i < (target as LocalPropSet).Props.Weights.Count; i++)
                showWeights.Add(false);
        }

        public override void OnInspectorGUI()
        {
            LocalPropSet propSet = target as LocalPropSet;

            if (propSet == null)
                return;

            EditorUtil.DrawIntRange("Count", propSet.PropCount);
			EditorGUILayout.Space();
            EditorUtil.DrawGameObjectChanceTableGUI("Prop", propSet.Props, showWeights, true);

            if (GUILayout.Button("Add Selected"))
            {
                foreach (var go in Selection.gameObjects)
                    if (!propSet.Props.ContainsGameObject(go))
                    {
                        propSet.Props.Weights.Add(new GameObjectChance(go));
                        showWeights.Add(false);
                    }
            }

            if (GUI.changed)
                EditorUtility.SetDirty(propSet);
        }
    }
}

