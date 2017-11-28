using UnityEngine;
using System.Collections;
using controller.animator;
using System;

namespace controller {
	namespace motor {
		public class NPC_motor : Motor {
			#region variables publicas
			public float runner_multiply = 2.0f;
			public float max_horizontal_speed = 10f;
			#endregion

			#region variables protegidas
			protected new NPC_animator _animator;
			public Vector2 _direction_vector = Vector2.zero;
			public bool _is_moving = false;
			public bool _is_running = false;
			#endregion

			#region propiedades publicas
			public bool is_running {
				get; set;
			}

			public Vector2 direction_vector {
				set {
					_direction_vector = value;
				}
				protected get {
					return _direction_vector;
				}
			}

			public bool is_moving {
				set {
					_is_moving = value;
				}
				protected get {
					return _is_moving;
				}
			}
			#endregion

			#region funciones protegidas
			/// <summary>
			/// actualiza el movimiento de NPC
			/// </summary>
			public override void update_motion() {
				//helper.vector2.if_need_normalize( ref _move_vector );
				Vector2 speed_vector = this._proccess_to_velocity();

				_rigidbody.velocity = speed_vector;
			}

			public override void update_animator() {
				_animator.direction_vector = direction_vector;
				_animator.is_moving = _rigidbody.velocity.magnitude > 0.1f;
				_animator.is_running = is_running;
			}

			protected override void _init_cache_animator() {
				_animator = GetComponent<animator.NPC_animator>();
			}

			protected virtual Vector2 _proccess_to_velocity()
			{
				float horizontal_speed = direction_vector.x * move_speed;
				horizontal_speed = Mathf.Clamp(
					horizontal_speed, -max_horizontal_speed, max_horizontal_speed);
				Vector2 speed_vector = new Vector2( horizontal_speed, 0 );
				if ( is_running )
					speed_vector *= runner_multiply;
				return new Vector2( speed_vector.x, _rigidbody.velocity.y );
			}

			public override void after_update_motor() {
				//direction_vector = Vector2.zero;
			}
			#endregion
		}
	}
}
