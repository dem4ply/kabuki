using UnityEngine;
using System.Collections.Generic;

namespace manager
{
	public class Collision_info {
		string name;
		GameObject game_object;
		Collision collision;

		public Collision_info( string name, Collision collision )
		{
			this.name = name;
			this.collision = collision;
			game_object = collision.gameObject;
		}
	}
}
