using UnityEngine;
using System.Collections;
using controller;
using controller.animator;
using chibi_base;

namespace controller {
	namespace controllers {
		public class Controller_2d : Chibi_behaviour {

			#region variables protected
			protected controller.motor.Motor_2d _motor;
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