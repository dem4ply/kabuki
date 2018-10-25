using UnityEngine;
using NUnit.Framework;
using controller.motor;

namespace weapon
{
	namespace ammo
	{
		public class Test_ammo
		{
			Ammo ammo;
			[SetUp]
			public void seet_up()
			{
				ammo = Ammo.CreateInstance<Ammo>().find_default<Ammo>();
			}

			[Test]
			public void should_have_a_default()
			{
				Assert.IsNotNull( ammo );
			}

			[Test]
			public void the_defaut_bullet_should_no_be_null()
			{
				Assert.IsNotNull( ammo.prefab_bullet );
			}

			[Test]
			public void the_instance_should_containt_a_bullet_motor()
			{
				var bullet = ammo.instanciate( Vector3.zero );
				var motor = bullet.GetComponent<Weapon_motor_3d>();
				Assert.IsNotNull( motor );
			}
		}
	}
}
