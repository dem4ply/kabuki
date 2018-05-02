using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_seek : Ai_steering_behavior
		{
			public GameObject target;

			protected virtual void Update()
			{
				do_seek( target );
			}
		}
	}
}