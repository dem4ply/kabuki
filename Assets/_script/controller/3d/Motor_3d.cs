using UnityEngine;
using System.Collections;
using controller;
using chibi_base;
using System;
using System.Collections.Generic;

namespace controller {
	namespace motor {
		public class Motor_3d : Motor_base {
			#region variables publicas
			#endregion

			#region variables protegidas
			protected Rigidbody _rigidbody;
			protected manager.Collision manager_collisions;
			#endregion

			#region propiedades publicas
			public override Vector3 direction_vector
			{
				set {
					_direction_vector = value;
				}
				protected get {
					return _direction_vector;
				}
			}

			public override Vector3 velocity_vector {
				get {
					return _rigidbody.velocity;
				}
			}
			#endregion

			#region funciones publicas
			public override void attack()
			{
				throw new NotImplementedException();
			}

			public override void jump()
			{
				throw new NotImplementedException();
			}

			public override void stop_attack()
			{
				throw new NotImplementedException();
			}

			public override void stop_jump()
			{
				throw new NotImplementedException();
			}

			public override void update_animator()
			{
				throw new NotImplementedException();
			}

			public override void update_motion()
			{
				throw new NotImplementedException();
			}
			#endregion

			/// <summary>
			/// inicializa el chache del script
			/// </summary>
			protected override void _init_cache() {
				base._init_cache();
				_rigidbody = GetComponent<Rigidbody>();
				manager_collisions = new manager.Collision();
			}
		}
	}
}