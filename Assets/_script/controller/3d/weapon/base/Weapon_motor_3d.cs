using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller
{
	namespace motor
	{
		public class Weapon_motor_3d : Motor_3d
		{
			#region funciones de movimiento
			public override void update_motion()
			{
			}
			#endregion

			public override void update_animator()
			{
			}

			protected override void _init_cache()
			{
				base._init_cache();
				_rigidbody.useGravity = false;
				_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			}
		}

	}
}
