﻿using UnityEngine;
using route;

namespace controller
{
	namespace ai
	{
		public class Ai_follow_path : Ai_steering_behavior
		{
			public GameObject target;

			protected virtual void Update()
			{
				do_follow_path( target );
			}
		}
	}
}
