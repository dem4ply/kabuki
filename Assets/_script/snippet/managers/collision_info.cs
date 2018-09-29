using UnityEngine;
using System.Collections.Generic;

namespace manager
{
	public class Collision_info {
		public string name;
		public GameObject game_object;
		public UnityEngine.Collision collision;

		public Collision_info( string name, UnityEngine.Collision collision )
		{
			this.name = name;
			this.collision = collision;
			game_object = collision.gameObject;
		}
	}
}
