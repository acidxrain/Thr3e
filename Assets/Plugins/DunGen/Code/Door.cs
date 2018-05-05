using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DunGen
{
	[Serializable]
	public class Door : MonoBehaviour
	{
		[HideInInspector]
		public Dungeon Dungeon;
		[HideInInspector]
		public Doorway DoorwayA;
		[HideInInspector]
		public Doorway DoorwayB;
		[HideInInspector]
		public Tile TileA;
		[HideInInspector]
		public Tile TileB;

		public virtual bool IsOpen
		{
			get { return isOpen; }
			set
			{
				isOpen = value;

				if (Dungeon != null && Dungeon.Culling != null)
					Dungeon.Culling.ChangeDoorState(this, isOpen);
			}
		}


		[SerializeField]
		private bool isOpen;
	}
}
