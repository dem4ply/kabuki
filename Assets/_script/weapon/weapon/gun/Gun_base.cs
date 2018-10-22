using UnityEngine;
using weapon.stat;
using weapon.ammo;
using controller.controllers;


namespace weapon
{
	namespace gun
	{
		public abstract class Gun_base : weapon.Weapon_base
		{
			public Gun_stat stat;
			public Ammo ammo;

			public override void attack()
			{
				shot();
			}

			public abstract Bullet_controller_3d shot();

			protected override void _init_cache()
			{
				base._init_cache();
				if ( ammo == null )
				{
					ammo = load_default_ammo() as Ammo;
				}
				if ( stat == null )
				{
					stat = load_default_stat() as Gun_stat;
				}
			}

			protected virtual chibi_base.Chibi_object load_default_ammo()
			{
				return Ammo.CreateInstance<Ammo>().find_default<Ammo>();
			}

			protected virtual chibi_base.Chibi_object load_default_stat()
			{
				return Gun_stat.CreateInstance<Gun_stat>()
					.find_default<Gun_stat>();
			}

		}
	}
}