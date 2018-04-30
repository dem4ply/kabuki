using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_walk : Ai
		{
			public Vector2 desire_direction = Vector2.left;

			protected virtual void Update()
			{
				controller.direction_vector = desire_direction;
			}

			protected virtual void OnDrawGizmos()
			{
				helper.draw.arrow.gizmo(
					transform.position, desire_direction, Color.magenta );
			}
		}
	}
}
