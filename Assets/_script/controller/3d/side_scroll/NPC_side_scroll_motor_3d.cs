using UnityEngine;
using System.Collections;
using System;


namespace controller
{
	namespace motor
	{
		public class NPC_side_scroll_motor_3d : NPC_motor_3d
		{
			public float max_jump_heigh = 4f;
			public float min_jump_heigh = 1f;
			public float jump_time = 0.4f;

			public float max_jump_velocity;
			public float min_jump_velocity;
			public float gravity = -9.8f;

			public bool try_to_jump_next_update = false;

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

			public override void jump()
			{
				try_to_jump_next_update = true;
			}

			public override void stop_jump()
			{
				try_to_jump_next_update = false;
			}

			protected override void Start()
			{
				base.Start();
				gravity = - ( 2 * max_jump_heigh ) / ( jump_time * jump_time );
				max_jump_velocity = Math.Abs( gravity ) * jump_time;
				min_jump_velocity = ( float )Math.Sqrt(
					2.0 * Math.Abs( gravity ) * min_jump_heigh );

			}
		}
	}
}

