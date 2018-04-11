using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using chibi_base;

namespace controller {
	namespace controllers {
		public class Controller_2d : Chibi_behaviour {

			#region variables protected
			[System.NonSerialized]
			public controller.motor.Motor_2d _motor;
			#endregion

			#region propiedades publicas
			public virtual bool is_running {
				set {
					_motor.is_running = value;
				}
			}

			/// <summary>
			/// modifca el vector de moviento del personaje
			/// </summary>
			public virtual Vector2 direction_vector{
				set {
					_motor.direction_vector = value;
				}
			}
			#endregion

			#region funciones publicas
			public virtual void jump()
			{
				_motor.jump();
			}

			public virtual void stop_jump()
			{
				_motor.stop_jump();
			}

			public virtual void attack()
			{
				Debug.Log( "atacando" );
				_motor.attack();
			}

			#endregion

			#region funciones protegidas
			protected override void _init_cache() {
				_init_cache_motor();
			}

			protected virtual void _init_cache_motor() {
				_motor = GetComponent<motor.Motor_2d>();
			}
			#endregion
		}
	}
}