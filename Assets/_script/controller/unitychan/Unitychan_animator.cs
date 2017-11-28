using UnityEngine;
using System.Collections;
using System;

namespace controller {
	namespace animator {
		public class Unitychan_animator : animator.NPC_animator {
			public float max_walk_speed = 0.5f;
			public float max_run_speed = 1.0f;

			public const string SPEED = "speed";

			public override Vector2 direction_vector {
				set {
					base.direction_vector = value;
					float max_value = is_running ? max_run_speed : max_walk_speed;
					float speed = Mathf.Clamp(
						Math.Abs( _move_vector.x ), 0.0f, max_value );
					animator.SetFloat( SPEED, speed );
				}
			}
		}
	}
}