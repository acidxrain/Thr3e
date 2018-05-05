using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace DunGen.Editor
{
    [CustomEditor(typeof(RuntimeDungeon))]
	public sealed class RuntimeDungeonInspector : UnityEditor.Editor
	{
        public override void OnInspectorGUI()
        {
            RuntimeDungeon dungeon = target as RuntimeDungeon;

            if (dungeon == null)
                return;

            dungeon.GenerateOnStart = EditorGUILayout.Toggle("Generate on Start", dungeon.GenerateOnStart);

            EditorGUILayout.BeginVertical("box");
            EditorUtil.DrawDungeonGenerator(dungeon.Generator, true);
            EditorGUILayout.EndVertical();

            if (GUI.changed)
                EditorUtility.SetDirty(dungeon);
        }
	}
}
