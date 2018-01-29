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

			public float force_of_jump = 150f;
			public float jump_velocity_change = 1f;
			public float jump_aceleration = 1f;
			public Vector2 ground_jump_vector = Vector2.up;
			public float min_jump_time = 0.5f;
			public float max_jump_time = 2f;


			public float jump_heigh = 4f;
			public float jump_time = 0.4f;

			public float jump_velocity;
			public float gravity = -9.8f;
			#endregion

			#region variables protegidas
			protected new NPC_animator_2d _animator;
			protected Vector2 _direction_vector = Vector2.zero;
			protected bool _is_moving = false;
			protected bool _is_running = false;
			protected bool try_to_jump_the_next_update = false;
			protected bool _is_grounded = false;

			protected float time_that_is_been_jumping = 0.0f;
			#endregion

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
					return manager_collisions.get( "is_grounded" );
				}
			}

			public virtual bool is_not_grounded
			{
				get {
					return !is_grounded;
				}
			}

			public virtual bool is_walled
			{
				get {
					return manager_collisions.get( "is_walled" );
				}
			}

			public virtual bool is_not_walled
			{
				get {
					return !is_walled;
				}
			}
			
			public virtual bool is_jumping
			{
				get;
				set;
			}

			#region funciones protegidas
			/// <summary>
			/// actualiza el movimiento de NPC
			/// </summary>
			public override void update_motion() {
				//helper.vector2.if_need_normalize( ref _move_vector );
				Vector2 speed_vector = _proccess_to_velocity();
				_process_jump( ref speed_vector );

				_rigidbody.velocity = speed_vector;
			}

			protected virtual void _process_jump( ref Vector2 speed_vector )
			{
				if ( try_to_jump_the_next_update && is_grounded )
					speed_vector.y = jump_velocity;
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
				if ( is_running )
					horizontal_speed *= runner_multiply;

				float vertical_speed = _rigidbody.velocity.y;
				vertical_speed += ( gravity * Time.deltaTime );

				return new Vector2( horizontal_speed, vertical_speed );
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

			protected virtual bool _is_the_collition_a_wall(
				Collision2D collision )
			{
				if ( collision.gameObject.tag == helper.consts.tags.scenary )
					foreach( ContactPoint2D contact in collision.contacts )
					{
						float angle = Vector2.Angle( Vector2.up, contact.normal );
						if ( helper.math.between( angle, 70, 110 ) )
							return true;
					}
				return false;
			}

			protected virtual void OnCollisionEnter2D( Collision2D collision )
			{
				bool is_floor = _is_the_collition_a_floor( collision );
				bool is_wall = _is_the_collition_a_wall( collision );
				manager_collisions.add(
					collision.gameObject, "is_grounded", is_floor);
				manager_collisions.add(
					collision.gameObject, "is_walled", is_wall );
			}
			protected virtual void OnCollisionExit2D( Collision2D collision )
			{
				manager_collisions.remove( collision.gameObject );
			}

			public virtual void jump()
			{
				try_to_jump_the_next_update = true;
				time_that_is_been_jumping = 0.0f;
			}
			public virtual void stop_jump()
			{
				try_to_jump_the_next_update = false;
			}

			protected override void Start()
			{
				base.Start();
				gravity = - ( 2 * jump_heigh ) / ( jump_time * jump_time );
				jump_velocity = Math.Abs( gravity ) * jump_time;
			}
			#endregion
		}
	}
}
