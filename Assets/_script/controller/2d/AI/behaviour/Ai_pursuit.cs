using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_pursuit : Ai_steering_behavior
		{
			public GameObject target;

			protected virtual void Update()
			{
				do_pursuit( target );
			}
		}
	}
}