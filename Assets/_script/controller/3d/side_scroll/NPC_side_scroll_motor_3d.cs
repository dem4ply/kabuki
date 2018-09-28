using UnityEngine;
using System.Collections;


namespace controller
{
	namespace motor
	{
		public class NPC_side_scroll_motor_3d : NPC_motor_3d
		{
			protected override void _proccess_ground_velocity(
				ref Vector3 velocity_vector )
			{
				Vector3 desire_speed_vector;
				// si es true se esta moviendo a toda velocidad en diagonal
				if ( direction_vector.magnitude > 1 )
					desire_speed_vector = direction_vector.normalized * max_speed;
				else
					desire_speed_vector = direction_vector * max_speed;

				if ( is_running )
					desire_speed_vector *= runner_multiply;

				// suavizado de la velocidad horizontal
				float final_horizontal_velocity = Mathf.SmoothDamp(
					velocity_vector.z, desire_speed_vector.x,
					ref horizontal_velocity_smooth, acceleration_time_in_ground );

				velocity_vector.x = final_horizontal_velocity;
			}
		}
	}
}

