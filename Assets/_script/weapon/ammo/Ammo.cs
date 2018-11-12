using UnityEngine;
using controller.controllers;
using controller.motor;
using damage;
using System.Collections.Generic;

namespace weapon
{
	namespace ammo
	{
		[ CreateAssetMenu( menuName="weapon/ammo/base") ]
		public class Ammo : chibi_base.Chibi_object
		{
			public Bullet_controller_3d prefab_bullet;

			public override string path_of_the_default
			{
				get { return "object/weapon/ammo/default"; }
			}

			public virtual Bullet_controller_3d instanciate_from_pool()
			{
				Bullet_controller_3d obj = helper.instantiate._( prefab_bullet );
				( ( Bullet_motor_3d )obj._motor ).ammo = this;
				return obj;
			}

			public virtual Bullet_controller_3d instanciate()
			{
				Bullet_controller_3d obj = 
					singleton.object_pool.Ammo_pool.instance.pop( this );
				return obj;
			}

			public virtual Bullet_controller_3d instanciate( Vector3 position )
			{
				Bullet_controller_3d obj = instanciate();
				obj.transform.position = position;
				return obj;
			}

			public virtual Bullet_controller_3d instanciate(
				Vector3 position, rol_sheet.Rol_sheet owner )
			{
				Bullet_controller_3d obj = instanciate( position );
				Damage[] damages = obj.damages;
				foreach ( Damage damage in damages )
					damage.owner = owner;
				return obj;
			}
		}
	}
}