using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DunGen
{
    [AddComponentMenu("DunGen/Runtime Dungeon")]
	public class RuntimeDungeon : MonoBehaviour
	{
        public DungeonGenerator Generator = new DungeonGenerator();
        public bool GenerateOnStart = true;


        protected virtual void Start()
        {
            if (Generator.Root == null)
                Generator.Root = gameObject;

            if (GenerateOnStart)
                Generator.Generate();
        }
	}
}
