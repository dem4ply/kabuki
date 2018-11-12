using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
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

			[UnityTest]
			public IEnumerator the_instance_should_containt_a_bullet_motor()
			{
				var bullet = ammo.instanciate( Vector3.zero );
				yield return new WaitForFixedUpdate();
				var motor = bullet.GetComponent<Bullet_motor_3d>();
				Assert.IsNotNull( motor );
			}

			[UnityTest]
			public IEnumerator the_instance_should_containt_the_ammo_ref()
			{
				var bullet = ammo.instanciate( Vector3.zero );
				yield return new WaitForFixedUpdate();
				var motor = bullet.GetComponent<Bullet_motor_3d>();
				Assert.AreEqual( ammo, motor.ammo );
			}
		}
	}
}
