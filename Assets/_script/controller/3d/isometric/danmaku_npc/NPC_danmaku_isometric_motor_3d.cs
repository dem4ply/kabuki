using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace controller
{
	namespace isometric
	{
		namespace motor
		{
			public class NPC_danmaku_isometric_motor_3d
				: NPC_fly_isometric_motor_3d
			{
				public weapon.gun.Gun_base[] guns;

				public override void attack()
				{
					foreach ( var gun in guns )
						gun.continue_shotting = true;
				}

				public override void stop_attack()
				{
					foreach ( var gun in guns )
						gun.continue_shotting = false;
				}

				protected void _find_my_guns()
				{
					guns = GetComponentsInChildren<weapon.gun.Gun_base>();
					foreach( weapon.gun.Gun_base gun in guns )
					{
						gun.owner = my_rol;
					}
				}

				protected override void _init_cache()
				{
					base._init_cache();
					_find_my_guns();
				}
			}
		}
	}
}
