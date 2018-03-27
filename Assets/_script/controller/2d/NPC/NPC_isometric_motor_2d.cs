using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller
{
	namespace motor
	{
		public class NPC_isometric_motor_2d : Motor_2d
		{
			public float acceleration_time_in_ground = 0.1f;
			protected float horizontal_velocity_smooth, vertical_velocity_smooth;

			#region funciones de movimiento
			public override void update_motion() {
				Vector2 velocity_vector = new Vector2(
					_rigidbody.velocity.x, _rigidbody.velocity.y );
				_proccess_ground_velocity( ref velocity_vector );
				_rigidbody.velocity = velocity_vector;
			}

			protected virtual void _proccess_ground_velocity(
				ref Vector2 velocity_vector )
			{
				Vector2 desire_speed_vector;
				// si es true se esta moviendo a toda velocidad en diagonal
				if ( direction_vector.magnitude > 1 )
					desire_speed_vector = direction_vector.normalized * move_speed;
				else
					desire_speed_vector = direction_vector * move_speed;

				if ( is_running )
					desire_speed_vector *= runner_multiply;

				float current_horizontal_velocity = velocity_vector.x;
				float current_vertical_velocity = velocity_vector.x;

				// suavizado de la velocidad horizontal
				float final_horizontal_velocity = Mathf.SmoothDamp(
					velocity_vector.x, desire_speed_vector.x,
					ref horizontal_velocity_smooth, acceleration_time_in_ground );

				float final_vertical_velocity = Mathf.SmoothDamp(
					velocity_vector.y, desire_speed_vector.y,
					ref vertical_velocity_smooth, acceleration_time_in_ground );

				velocity_vector.x = final_horizontal_velocity;
				velocity_vector.y = final_vertical_velocity;
			}
			#endregion

			#region funciones de animacion
			public override void update_animator() {
				//throw new NotImplementedException();
			}
			#endregion

			public override void jump()
			{
			}
			public override void stop_jump()
			{
			}

		}

	}
}
