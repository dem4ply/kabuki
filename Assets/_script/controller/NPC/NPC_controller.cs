using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller {
	namespace controllers {
		public class NPC_controller : Controller {

			#region variables protected
			protected new NPC_motor _motor;
			#endregion

			#region propiedades publicas
			/// <summary>
			/// modifca el vector de moviento del personaje
			/// </summary>
			public virtual Vector2 direction_vector{
				set {
					_motor.direction_vector = value;
				}
			}

			public bool is_moving {
				set {
					_motor.is_moving = value;
				}
			}

			public virtual bool is_running {
				set {
					_motor.is_running = value;
				}
			}
			#endregion

			#region funciones protegidas
			protected override void _init_cache_motor() {
				_motor = GetComponent<motor.NPC_motor>();
			}
			#endregion
		}
	}
}
