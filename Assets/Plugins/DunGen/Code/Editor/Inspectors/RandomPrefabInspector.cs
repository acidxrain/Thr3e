using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DunGen.Editor
{
    [CustomEditor(typeof(RandomPrefab))]
    public class RandomPrefabInspector : UnityEditor.Editor
    {
        private readonly List<bool> showWeights = new List<bool>();


        private void OnEnable()
        {
            for (int i = 0; i < (target as RandomPrefab).Props.Weights.Count; i++)
                showWeights.Add(false);
        }

        public override void OnInspectorGUI()
        {
            RandomPrefab prop = target as RandomPrefab;

            if (prop == null)
                return;

            EditorUtil.DrawGameObjectChanceTableGUI("Prefab", prop.Props, showWeights);

            if (GUI.changed)
                EditorUtility.SetDirty(prop);
        }
    }
}

