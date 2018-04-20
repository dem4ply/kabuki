using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_seek : Ai_walk
		{
			public GameObject target;

			protected override void Update()
			{
				desire_direction = target.transform.position
					- controller.transform.position;
				desire_direction.Normalize();
				base.Update();
			}
		}
	}
}
