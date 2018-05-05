using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DunGen
{
    [AddComponentMenu("DunGen/Random Props/Local Prop Set")]
	public class LocalPropSet : RandomProp
	{
        public GameObjectChanceTable Props = new GameObjectChanceTable();
        public IntRange PropCount = new IntRange(1, 1);


        public override void Process(System.Random randomStream, Tile tile)
        {
            var propTable = Props.Clone();

            int count = PropCount.GetRandom(randomStream);
            count = Mathf.Clamp(count, 0, Props.Weights.Count);

            List<GameObject> toKeep = new List<GameObject>(count);

			for (int i = 0; i < count; i++)
			{
				var chosenEntry = propTable.GetRandom(randomStream, tile.Placement.IsOnMainPath, tile.Placement.NormalizedDepth, null, true, true);

				if(chosenEntry != null && chosenEntry.Value != null)
					toKeep.Add(chosenEntry.Value);
			}

            foreach (var prop in Props.Weights)
                if (!toKeep.Contains(prop.Value))
                    UnityUtil.Destroy(prop.Value);
        }
	}
}
