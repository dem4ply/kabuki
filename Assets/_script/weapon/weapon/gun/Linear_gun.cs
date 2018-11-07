using UnityEngine;
using controller.controllers;
using rol_sheet;

namespace weapon
{
	namespace gun
	{
		public class Linear_gun : Gun_base
		{
			protected bool _continue_shotting = false;
			public bool continue_shotting
			{
				get { return _continue_shotting; }
				set {
					_continue_shotting = value;
					if ( value )
						start_shoting();
				}
			}

			public Vector3 direction_shot
			{
				get { return transform.forward.normalized; }
			}

			public override Bullet_controller_3d shot()
			{
				var bullet = ammo.instanciate( transform.position );
				bullet.shot( direction_shot );
				return bullet;
			}

			public override Bullet_controller_3d shot( Rol_sheet owner )
			{
				var bullet = ammo.instanciate( transform.position, owner );
				bullet.shot( direction_shot );
				return bullet;
			}

			public virtual void start_shoting()
			{
				shot();
				Invoke( "shot", 1 * stat.rate_fire );
			}

			public virtual void stop_shotting()
			{
				continue_shotting = false;
			}


			protected void OnDrawGizmos()
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere( transform.position, 0.2f );
				Gizmos.color = Color.red;
				helper.draw.arrow.gizmo( transform.position, direction_shot );
			}

		}
	}
}