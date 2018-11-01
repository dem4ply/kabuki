using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.gun;
using tests_tool;

namespace weapon
{
	namespace bullet
	{
		public class Test_bullet_should_be_destroy_when_touch_a_target
		{
			GameObject scene, weapon;
			Assert_colision target;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_test/scene/weapon/gun/" +
						"linear_gun_with_target" ) as GameObject;
				scene = helper.instantiate._( scene );
				weapon = scene.transform.Find( "weapon_base" ).gameObject;
				target = helper.game_object.Find._<Assert_colision>(
					scene, "assert_collision" );
			}

			[TearDown]
			public void clean_scenary()
			{
				MonoBehaviour.DestroyImmediate( scene );
			}

			[UnityTest]
			public IEnumerator when_hit_should_destroy_the_bullet()
			{
				Linear_gun gun = weapon.GetComponent<Linear_gun>();
				var bullet = gun.shot();
				yield return new WaitForSeconds( 1 );
				helper.game_object.comp.is_null( bullet );
				target.assert_not_collision_enter();
			}
		}
	}
}
