using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;

namespace weapon
{
	namespace bullet
	{
		public class Test_bullet
		{
			GameObject bullet, scene, weapon;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_prefab/tests/weapon/basic_weapon_chamber" ) as GameObject;
				scene = helper.instantiate._( scene );
				Debug.Log( scene );
				bullet = scene.transform.Find( "bullet_base" ).gameObject;
				weapon = scene.transform.Find( "weapon_base" ).gameObject;
			}

			[TearDown]
			public void clean_scenary()
			{
				MonoBehaviour.DestroyImmediate( scene );
			}

			[UnityTest]
			public IEnumerator bullet_should_no_be_affected_by_gravity()
			{
				Vector3 start_position = bullet.transform.position;
				yield return new WaitForSeconds( 1 );
				Vector3 end_position = bullet.transform.position;
				Assert.AreEqual( start_position.x, end_position.x, 0.01f );
				Assert.AreEqual( start_position.y, end_position.y, 0.01f );
				Assert.AreEqual( start_position.z, end_position.z, 0.01f );
			}

			[UnityTest]
			public IEnumerator shot_should_set_the_velocity()
			{
				Bullet_base bullet_instance = bullet.GetComponent<Bullet_base>();
				bullet_instance.shot( bullet.transform.forward );
				Rigidbody bullet_rigidbody = bullet.GetComponent<Rigidbody>();
				yield return new WaitForSeconds( 1 );
				Debug.Log( bullet_rigidbody );
				Assert.AreEqual(
					bullet_instance.max_speed * bullet.transform.forward,
					bullet_rigidbody.velocity );
			}
		}
	}
}
