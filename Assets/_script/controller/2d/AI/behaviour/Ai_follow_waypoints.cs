﻿using UnityEngine;
using route;

namespace controller
{
	namespace ai
	{
		public class Ai_follow_waypoints : Ai_steering_behavior
		{
			public GameObject target;

			protected virtual void Update()
			{
				do_follow_waypoints( target );
			}
		}
	}
}
