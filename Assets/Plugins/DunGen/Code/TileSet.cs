using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DunGen
{
    /// <summary>
    /// A set of tiles with weights to be picked from at random
    /// </summary>
    [Serializable]
	public sealed class TileSet : ScriptableObject
	{
        public GameObjectChanceTable TileWeights = new GameObjectChanceTable();
		public List<LockedDoorwayAssociation> LockPrefabs = new List<LockedDoorwayAssociation>();
    }
}
