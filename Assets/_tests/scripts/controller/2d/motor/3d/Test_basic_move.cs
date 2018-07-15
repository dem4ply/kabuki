using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace controller
{
	namespace motor
	{
		namespace tree_d
		{

			public class Test_basic_move
			{
				GameObject player, scene;
				tests_tool.Assert_colision north, south, west, east;

				[SetUp]
				public void Instanciate_scenary()
				{
					scene =
						Resources.Load(
							"_test/scene/controller/3d/basic_move" ) as GameObject;
					scene = helper.instantiate._( scene );
					player = scene.transform.Find( "player" ).gameObject;
					north = scene.transform.Find( "assert_collision_north" )
						.GetComponent<tests_tool.Assert_colision>();
					south = scene.transform.Find( "assert_collision_south" )
						.GetComponent<tests_tool.Assert_colision>();
					west = scene.transform.Find( "assert_collision_west" )
						.GetComponent<tests_tool.Assert_colision>();
					east = scene.transform.Find( "assert_collision_east" )
						.GetComponent<tests_tool.Assert_colision>();
				}

				[TearDown]
				public void clean_scenary()
				{
					MonoBehaviour.DestroyImmediate( scene );
				}

				[UnityTest]
				public IEnumerator when_the_direction_is_up_should_touch_north()
				{
					var ai = player.GetComponent<ai.Ai_walk>();
					ai.desire_direction = Vector2.up;
					yield return new WaitForSeconds( 1 );
					north.assert_collision_enter( ai.gameObject );
					west.assert_not_collision_enter();
					east.assert_not_collision_enter();
					south.assert_not_collision_enter();
				}

				[UnityTest]
				public IEnumerator when_the_direction_is_down_should_touch_south()
				{
					var ai = player.GetComponent<ai.Ai_walk>();
					ai.desire_direction = Vector2.down;
					yield return new WaitForSeconds( 1 );
					south.assert_collision_enter( ai.gameObject );
					west.assert_not_collision_enter();
					east.assert_not_collision_enter();
					north.assert_not_collision_enter();
				}

				[UnityTest]
				public IEnumerator when_the_direction_is_left_should_touch_west()
				{
					var ai = player.GetComponent<ai.Ai_walk>();
					ai.desire_direction = Vector2.left;
					yield return new WaitForSeconds( 1 );
					west.assert_collision_enter( ai.gameObject );
					north.assert_not_collision_enter();
					east.assert_not_collision_enter();
					south.assert_not_collision_enter();
				}

				[UnityTest]
				public IEnumerator when_the_direction_is_right_should_touch_east()
				{
					var ai = player.GetComponent<ai.Ai_walk>();
					ai.desire_direction = Vector2.right;
					yield return new WaitForSeconds( 1 );
					east.assert_collision_enter( ai.gameObject );
					north.assert_not_collision_enter();
					west.assert_not_collision_enter();
					south.assert_not_collision_enter();
				}
				/*

				[UnityTest]
				public IEnumerator if_move_to_down_should_only_decrese_the_y()
				{
					var ai = player.GetComponent<controller.ai.Ai_walk>();
					ai.transform.position = Vector2.zero;
					ai.desire_direction = Vector2.down;
					yield return new WaitForSeconds( 1 );
					Assert.Less( player.transform.position.x, 0.1f );
					Assert.Less( player.transform.position.y, 0 );
				}

				[UnityTest]
				public IEnumerator if_move_to_left_should_only_decrese_the_x()
				{
					var ai = player.GetComponent<controller.ai.Ai_walk>();
					ai.transform.position = Vector2.zero;
					ai.desire_direction = Vector2.left;
					yield return new WaitForSeconds( 1 );
					Assert.Less( player.transform.position.x, 1 );
					Assert.Less( player.transform.position.y, 0.1f );
				}

				[UnityTest]
				public IEnumerator if_move_to_right_should_only_decrese_the_x()
				{
					var ai = player.GetComponent<controller.ai.Ai_walk>();
					ai.transform.position = Vector2.zero;
					ai.desire_direction = Vector2.right;
					yield return new WaitForSeconds( 1 );
					Assert.Greater( player.transform.position.x, 1 );
					Assert.Less( player.transform.position.y, 0.1f );
				}
				*/
			}
		}
	}
}
