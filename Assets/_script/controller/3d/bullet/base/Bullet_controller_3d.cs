using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

namespace controller
{
	namespace controllers
	{
		public class Bullet_controller_3d : Controller_3d
		{
			public void shot( Vector3 direction_shot )
			{
				desire_direction = direction_shot;
			}
		}

	}
}
