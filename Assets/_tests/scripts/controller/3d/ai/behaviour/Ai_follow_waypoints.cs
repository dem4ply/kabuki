using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.ai;
using controller.controllers;
using tests_tool;

namespace ai
{
	namespace tree_d
	{
		namespace behavior
		{
			public class Test_ai_follow_waypoints
			{
				GameObject player, scene, collider;
				Assert_colision p1, p2, p3, p4, p5, p6, p7, p8;

				[SetUp]
				public void Instanciate_scenary()
				{
					scene =
						Resources.Load(
							"_test/scene/ai/"
							+ "basic_waypoints" ) as GameObject;
					scene = helper.instantiate._( scene );
					player = scene.transform.Find( "player" ).gameObject;
					collider = helper.game_object.Find._( player, "Sphere" );
					p1 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p1" );
					p2 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p2" );
					p3 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p3" );
					p4 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p4" );
					p5 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p5" );
					p6 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p6" );
					p7 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p7" );
					p8 = helper.game_object.Find._<Assert_colision>(
						scene, "assert_collision_p8" );
				}

				[TearDown]
				public void clean_scenary()
				{
					MonoBehaviour.DestroyImmediate( scene );
				}

				[UnityTest]
				public IEnumerator agent_shold_touch_all_colliders()
				{
					yield return new WaitForSeconds( 4 );
					p1.assert_collision_enter( collider );
					p2.assert_collision_enter( collider );
					p3.assert_collision_enter( collider );
					p4.assert_collision_enter( collider );
					p5.assert_collision_enter( collider );
					p6.assert_collision_enter( collider );
					p7.assert_collision_enter( collider );
					p8.assert_collision_enter( collider );
				}
			}
		}
	}
}
