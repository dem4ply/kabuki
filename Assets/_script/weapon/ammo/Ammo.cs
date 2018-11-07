using UnityEngine;
using controller.controllers;
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

			public virtual Bullet_controller_3d instanciate( Vector3 position )
			{
				Bullet_controller_3d obj = helper.instantiate._(
					prefab_bullet, position );
				return obj;
			}

			public virtual Bullet_controller_3d instanciate(
				Vector3 position, rol_sheet.Rol_sheet owner )
			{
				Bullet_controller_3d obj = helper.instantiate._(
					prefab_bullet, position );
				Damage[] damages = obj.damages;
				foreach ( Damage damage in damages )
					damage.owner = owner;
				return obj;
			}
		}
	}
}