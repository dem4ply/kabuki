using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;
using tests_tool;

namespace weapon
{
	namespace gun
	{
		public class Test_gun_linear
		{
			GameObject scene, weapon;
			Assert_colision target;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_test/scene/weapon/gun/" +
						"linear_gun_wintout_assets" ) as GameObject;
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
			public IEnumerator when_shoot_should_using_the_default_ammo()
			{
				Linear_gun gun = weapon.GetComponent<Linear_gun>();
				var bullet = gun.shot();
				yield return new WaitForSeconds( 1 );
				target.assert_collision_enter( bullet );
				MonoBehaviour.DestroyImmediate( bullet );
			}

			[UnityTest]
			public IEnumerator when_stop_to_shotting_should_no_made_more_shots()
			{
				Linear_gun gun = weapon.GetComponent<Linear_gun>();
				gun.continue_shotting = true;
				float shot_time = 1 / gun.stat.rate_fire;
				shot_time *= 3;
				yield return new WaitForSeconds( shot_time );
				gun.continue_shotting = false;
				yield return new WaitForSeconds( 2f );
				target.assert_collision_enter_less_that(
					(int)gun.stat.rate_fire * 3 );
			}
		}
	}
}
