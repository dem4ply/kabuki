using UnityEngine;
using System.Collections;
using controller;
using chibi_base;
using System;
using System.Collections.Generic;

namespace controller {
	namespace motor {
		public class Motor_2d : Chibi_behaviour {
			#region variables publicas
			public float max_speed = 10f;
			public float runner_multiply = 2.0f;
			#endregion

			#region variables protegidas
			protected Transform _transform;
			protected Rigidbody2D _rigidbody;
			protected Vector2 _move_vector;
			protected Vector2 _direction_vector = Vector2.zero;
			protected bool _is_dead = false;

			protected manager.Collision manager_collisions;

			[System.NonSerialized]
			protected animator.Animator_base _animator;
			#endregion

			#region propiedades publicas
			/// <summary>
			/// Vector de movimiento que se usara en la proxima actualizacion
			/// </summary>
			public virtual Vector2 move_vector {
				get {
					return _move_vector;
				}
				set {
					_move_vector = value;
				}
			}

			public Vector2 direction_vector {
				set {
					_direction_vector = value;
				}
				protected get {
					return _direction_vector;
				}
			}

			public virtual void jump()
			{
				throw new NotImplementedException();
			}
			public virtual void stop_jump()
			{
				throw new NotImplementedException();
			}

			public bool is_running {
				get; set;
			}

			public bool is_dead
			{
				get {
					return _is_dead;
				}
				protected set {
					_is_dead = value;
				}
			}
			public bool is_not_dead {
				get {
					return !is_dead; }
			}

			public Vector2 velocity_vector {
				get {
					return _rigidbody.velocity;
				}
			}

			public float current_max_speed {
				get {
					if ( is_running )
						return max_speed * runner_multiply;
					return max_speed;
				}
			}
			#endregion

			protected void FixedUpdate() {
			//protected void Update() {
				update_motor();
			}
			/// <summary>
			/// inicializa el chache del script
			/// </summary>
			protected override void _init_cache() {
				_transform = transform;
				_rigidbody = GetComponent<Rigidbody2D>();
				_init_cache_animator();
				manager_collisions = new manager.Collision();

				_rigidbody.gravityScale = 0f;
			}

			protected virtual void _init_cache_animator() {
				_animator = GetComponent<animator.Animator_base>();
			}

			public virtual void update_motor() {
				update_motion();
				update_animator();
				after_update_motor();
			}

			public virtual void update_motion() {
				throw new NotImplementedException();
			}

			public virtual void update_animator() {
				throw new NotImplementedException();
			}

			public virtual void attack() {
				throw new NotImplementedException();
			}

			public virtual void stop_attack() {
				throw new NotImplementedException();
			}

			public virtual void died()
			{
				is_dead = true;
			}

			public virtual void after_update_motor() {
			}
		}
	}
}