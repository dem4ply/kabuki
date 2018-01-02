using UnityEngine;
using System.Collections;
using controller.animator;
using System;

namespace controller {
	namespace motor {
		public class NPC_side_scroll_motor_2d : Motor_2d {
			#region variables publicas
			float runner_multiply = 2.0f;
			public float max_horizontal_speed = 10f;

			public float force_of_jump = 10f;
			#endregion

			#region variables protegidas
			protected new NPC_animator_2d _animator;
			public Vector2 _direction_vector = Vector2.zero;
			public bool _is_moving = false;
			public bool _is_running = false;
			public bool try_to_jump_the_next_update = false;
			public bool _is_grounded = false;
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

			public virtual bool is_grounded
			{
				get {
					return _is_grounded;
				}
				set {
					_is_grounded = value;
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

				if ( this.try_to_jump_the_next_update && this.is_grounded )
				{
					_rigidbody.AddForce( new Vector2( 0, force_of_jump ) );
					try_to_jump_the_next_update = false;
					is_grounded = false;
				}
			}

			public override void update_animator() {
				_animator.direction_vector = direction_vector;
				_animator.is_moving = _rigidbody.velocity.magnitude > 0.1f;
				_animator.is_running = is_running;
			}

			protected override void _init_cache_animator() {
				_animator = GetComponent<animator.NPC_animator_2d>();
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

			protected virtual bool _is_the_collition_a_floor(
				Collision2D collision )
			{
				if ( collision.gameObject.tag == helper.consts.tags.scenary )
					foreach( ContactPoint2D contact in collision.contacts )
					{
						float angle = Vector2.Angle( Vector2.left, contact.normal );
						if ( helper.math.between( angle, 20, 160 ) )
							return true;
					}
				return false;
			}

			protected virtual void OnCollisionStay2D( Collision2D collision )
			{
				bool is_floor = this._is_the_collition_a_floor( collision );
				if ( is_floor )
					is_grounded = true;
			}

			protected virtual void OnCollisionEnter2D( Collision2D collision )
			{
				bool is_floor = this._is_the_collition_a_floor( collision );
				if ( is_floor )
					is_grounded = true;
			}

			public virtual void jump()
			{
				this.try_to_jump_the_next_update = true;
			}
			#endregion
		}
	}
}
