using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace route
{
	public class Route_with_spawn : Route
	{
		public spawner.Spawn_point proto_spawn_point;
		protected override IEnumerable<GameObject> get_points()
		{
			yield return proto_spawn_point.gameObject;
			for ( int i = 1; i < nodes; ++i )
				yield return proto_point;
		}
	}
}