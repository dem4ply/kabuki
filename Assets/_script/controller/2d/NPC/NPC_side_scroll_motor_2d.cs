using UnityEngine;
using System.Collections;
using controller.animator;
using System;

namespace controller {
	namespace motor {
		public class NPC_side_scroll_motor_2d : Motor_2d {
			#region variables publicas
			float runner_multiply = 2.0f;

			public float min_jump_time = 0.5f;
			public float max_jump_time = 2f;

			public float jump_heigh = 4f;
			public float jump_time = 0.4f;

			public float jump_velocity;
			public float gravity = -9.8f;

			public float multiplier_velocity_wall_slice = 0.8f;

			public Vector2 wall_jump_climp;
			public Vector2 wall_jump_off;
			public Vector2 wall_jump_leap;

			float acceleration_time_in_ground = 0.1f;
			float acceleration_time_in_air = 0.2f;
			#endregion

			#region variables protegidas
			protected new NPC_animator_2d _animator;
			protected Vector2 _direction_vector = Vector2.zero;
			protected bool _is_moving = false;
			protected bool _is_running = false;
			protected bool try_to_jump_the_next_update = false;
			protected bool _is_grounded = false;

			protected float time_that_is_been_jumping = 0.0f;

			protected float horizontal_velocity_smooth;
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

			public virtual bool is_walled_left
			{
				get {
					return manager_collisions.get( "is_walled_left" );
				}
			}

			public virtual bool is_walled_right
			{
				get {
					return manager_collisions.get( "is_walled_right" );
				}
			}

			public virtual bool no_is_walled_left
			{
				get {
					return !is_walled_left;
				}
			}

			public virtual bool no_is_walled_right
			{
				get {
					return !is_walled_right;
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
				Vector2 velocity_vector = new Vector2(
					_rigidbody.velocity.x, _rigidbody.velocity.y );

				_proccess_to_velocity( ref velocity_vector );
				_proccess_gravity( ref velocity_vector );
				_process_jump( ref velocity_vector );

				_rigidbody.velocity = velocity_vector;
			}

			protected virtual void _proccess_to_velocity(
				ref Vector2 velocity_vector )
			{
				float desire_horizontal_velocity = direction_vector.x * move_speed;
				if ( is_running )
					desire_horizontal_velocity *= runner_multiply;

				float current_horizontal_velocity = velocity_vector.x;

				float acceleration_time = 0f;
				if ( is_grounded )
					acceleration_time = acceleration_time_in_ground;
				else
					acceleration_time = acceleration_time_in_air;

				// suavizado de la velocidad horizontal
				float final_horizontal_velocity = Mathf.SmoothDamp(
					current_horizontal_velocity, desire_horizontal_velocity,
					ref horizontal_velocity_smooth, acceleration_time_in_ground );

				velocity_vector.x = final_horizontal_velocity;
			}

			protected virtual void _proccess_gravity(
				ref Vector2 velocity_vector )
			{
				velocity_vector.y += ( gravity * Time.deltaTime );

				if ( is_not_grounded && is_walled )
					velocity_vector.y *= multiplier_velocity_wall_slice;
			}


			protected virtual void _process_jump( ref Vector2 speed_vector )
			{
				if ( try_to_jump_the_next_update )
				{
					if ( is_walled && is_not_grounded)
					{
						int jump_direction = is_walled_left ? -1 : 1;
						if ( Math.Sign( direction_vector.x ) == jump_direction )
						{
							Debug.Log( "jump climp" );
							speed_vector.x = -jump_direction * wall_jump_climp.x;
							speed_vector.y = wall_jump_climp.y;
						}
						else if ( direction_vector.x == 0)
						{
							speed_vector.x = -jump_direction * wall_jump_off.x;
							speed_vector.y = wall_jump_off.y;
							Debug.Log( string.Format( "jump off :: {0}", speed_vector ) );
						}
						else
						{
							Debug.Log( "jump leap" );
							speed_vector.x = -jump_direction * wall_jump_leap.x;
							speed_vector.y = wall_jump_leap.y;
						}
					}
					else if ( is_grounded )
						speed_vector.y = jump_velocity;
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

			protected virtual void _is_the_collition_a_floor(
				Collision2D collision )
			{
				if ( collision.gameObject.tag == helper.consts.tags.scenary )
					foreach( ContactPoint2D contact in collision.contacts )
					{
						float angle = Vector2.Angle( Vector2.left, contact.normal );
						if ( helper.math.between( angle, 20, 160 ) )
						{
							manager_collisions.add(
								collision.gameObject, "is_grounded", true );
							return;
						}
					}
			}

			protected virtual void _is_the_collition_a_wall(
				Collision2D collision )
			{
				if ( collision.gameObject.tag == helper.consts.tags.scenary )
					foreach( ContactPoint2D contact in collision.contacts )
					{
						float angle = Vector2.Angle( Vector2.up, contact.normal );
						if ( helper.math.between( angle, 70, 110 ) )
						{
							manager_collisions.add(
								collision.gameObject, "is_walled", true );
							if ( contact.normal.x > 0 )
							{
								manager_collisions.add(
									collision.gameObject, "is_walled_left", true );
								manager_collisions.add(
									collision.gameObject, "is_walled_right", false );
							}
							else if ( contact.normal.x < 0 )
							{
								manager_collisions.add(
									collision.gameObject, "is_walled_right", true );
								manager_collisions.add(
									collision.gameObject, "is_walled_left", false );
							}
							return;
						}
					}
			}

			protected virtual void OnCollisionEnter2D( Collision2D collision )
			{
				_is_the_collition_a_floor( collision );
				_is_the_collition_a_wall( collision );
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
