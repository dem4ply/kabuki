using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace weapon
{
	namespace weapon
	{
		public class Test_waepon
		{
			GameObject scene, weapon;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_prefab/tests/weapon/basic_weapon_chamber" ) as GameObject;
				scene = helper.instantiate._( scene );
				weapon = scene.transform.Find( "weapon_base" ).gameObject;
			}

			[TearDown]
			public void clean_scenary()
			{
				MonoBehaviour.DestroyImmediate( scene );
			}

			[UnityTest]
			public IEnumerator shot_should_create_a_bullet()
			{
				Weapon_base weapon_instance = weapon.GetComponent<Weapon_base>();

				yield return new WaitForSeconds( 0.1f );
				GameObject bullet_clone = weapon_instance.shot();
				yield return new WaitForSeconds( 0.1f );
				GameObject bullet_finded_in_scenary = GameObject.Find(
					bullet_clone.name );

				Assert.IsNotNull( bullet_finded_in_scenary );
				MonoBehaviour.DestroyImmediate( bullet_clone );
			}

			[UnityTest]
			public IEnumerator shot_should_move_the_bullet()
			{
				Weapon_base weapon_instance = weapon.GetComponent<Weapon_base>();
				GameObject bullet_clone = weapon_instance.shot();

				yield return new WaitForSeconds( 1f );
				GameObject bullet_finded_in_scenary = GameObject.Find(
					bullet_clone.name );

				Rigidbody bullet_rigidbody = bullet_finded_in_scenary
					.GetComponent<Rigidbody>();
				Assert.AreEqual(
					weapon.transform.forward.normalized,
					bullet_rigidbody.velocity.normalized );

				MonoBehaviour.DestroyImmediate( bullet_clone );
			}
		}
	}
}
