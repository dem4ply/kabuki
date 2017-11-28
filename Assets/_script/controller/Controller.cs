using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using chibi_base;

namespace controller {
	namespace controllers {
		public class Controller : Chibi_behaviour {

			#region variables protected
			protected controller.motor.Motor _motor;
			#endregion

			#region funciones protegidas
			protected override void _init_cache() {
				_init_cache_motor();
			}

			protected virtual void _init_cache_motor() {
				_motor = GetComponent<motor.Motor>();
			}
			#endregion
		}
	}
}