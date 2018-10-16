using UnityEngine;
using System.Collections;

namespace spawner
{
	public class Spawn_to_route : Spawn_point
	{
		public route.Route target;

		public override GameObject spawn()
		{
			var result = base.spawn();
			var ai = result.GetComponent<controller.ai.Ai_steering_behavior>();
			if ( target != null && ai != null )
				ai.target = target.gameObject;
			return result;
		}
	}
}
