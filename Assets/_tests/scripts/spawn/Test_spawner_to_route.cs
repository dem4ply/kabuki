using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;
using tests_tool;

namespace spawner
{
	public class Test_spawner_to_route
	{
		GameObject scene, route;
		Spawn_point spawn_point;
		Assert_colision p0, p1, p2, p3, p4, p5, p6, p7, p8, p9;

		[SetUp]
		public void Instanciate_scenary()
		{
			scene =
				Resources.Load(
					"_prefab/tests/spawn/spawn_to_route" ) as GameObject;
			scene = helper.instantiate._( scene );
			spawn_point = helper.game_object.Find._<Spawn_point>(
				scene, "spawn_point" ) ;
			route = helper.game_object.Find._( scene, "route" );
			p0 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_0" );
			p1 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_1" );
			p2 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_2" );
			p3 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_3" );
			p4 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_4" );
			p5 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_5" );
			p6 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_6" );
			p7 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_7" );
			p8 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_8" );
			p9 = helper.game_object.Find._<Assert_colision>(
				scene, "point_assert_9" );
		}

		[TearDown]
		public void clean_scenary()
		{
			MonoBehaviour.DestroyImmediate( scene );
		}

		[UnityTest]
		public IEnumerator should_set_the_target_to_route()
		{
			yield return new WaitForSeconds( 0.1f );
			GameObject obj = spawn_point.spawn();
			yield return new WaitForSeconds( 1.0f );
			var ai = obj.GetComponent<controller.ai.Ai_follow_waypoints>();
			Assert.AreEqual( ai.target, route );
			MonoBehaviour.DestroyImmediate( obj );
		}

		[UnityTest]
		public IEnumerator when_spawn_one_obj_shoud_collide_with_all_assert()
		{
			yield return new WaitForSeconds( 0.1f );
			GameObject obj = spawn_point.spawn();
			yield return new WaitForSeconds( 5.0f );
			p0.assert_collision_enter( obj );
			p1.assert_collision_enter( obj );
			p2.assert_collision_enter( obj );
			p3.assert_collision_enter( obj );
			p4.assert_collision_enter( obj );
			p5.assert_collision_enter( obj );
			p6.assert_collision_enter( obj );
			p7.assert_collision_enter( obj );
			p8.assert_collision_enter( obj );
			p9.assert_collision_enter( obj );
		}
	}
}
