using UnityEngine;
using System.Collections;
using controller;
using chibi_base;
using System;
using System.Collections.Generic;

namespace controller {
	namespace motor {
		public abstract class Motor_base : Chibi_behaviour {
			#region variables publicas
			public float max_speed = 10f;
			public float runner_multiply = 2.0f;
			#endregion

			#region variables protegidas
			protected Transform _transform;
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
			public abstract Vector2 move_vector
			{
				get; set;
			}

			public abstract Vector2 direction_vector
			{
				protected get; set;
			}

			public abstract void jump();
			public abstract void stop_jump();

			public abstract bool is_running
			{
				get; set;
			}

			public abstract bool is_dead
			{
				get; protected set;
			}
			public abstract bool is_not_dead
			{
				get;
			}

			public abstract Vector2 velocity_vector
			{
				get;
			}

			public abstract float current_max_speed
			{
				get;
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
				_init_cache_animator();
				manager_collisions = new manager.Collision();
			}

			protected virtual void _init_cache_animator() {
				_animator = GetComponent<animator.Animator_base>();
			}

			public void update_motor() {
				update_motion();
				update_animator();
				after_update_motor();
			}

			public abstract void update_motion();

			public abstract void update_animator();

			public abstract void attack();

			public abstract void stop_attack();

			public virtual void died()
			{
				is_dead = true;
			}

			public virtual void after_update_motor() {
			}
		}
	}
}