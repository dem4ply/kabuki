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
			public float move_speed = 10f;
			#endregion

			#region variables protegidas
			protected Transform _transform;
			protected Rigidbody2D _rigidbody;
			protected Vector2 _move_vector;

			protected Dictionary<GameObject, Vector3> collitions;

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
			#endregion

			#region funcion publicas
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
			}

			protected virtual void _init_cache_animator() {
				_animator = GetComponent<animator.Animator_base>();
			}

			public void update_motor() {
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

			public virtual void after_update_motor() {
			}
		}
	}
}