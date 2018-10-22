using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				public class Test_ai_walk_3d
				{
					GameObject player, collider, scene;
					tests_tool.Assert_colision up, down, left, right, center;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
						      "ai/ai_walk" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
						collider = helper.game_object.Find._( player, "Sphere" );
						up = scene.transform.Find( "assert_collision_up" )
							.GetComponent<tests_tool.Assert_colision>();
						down = scene.transform.Find( "assert_collision_down" )
							.GetComponent<tests_tool.Assert_colision>();
						left = scene.transform.Find( "assert_collision_left" )
							.GetComponent<tests_tool.Assert_colision>();
						right = scene.transform.Find( "assert_collision_right" )
							.GetComponent<tests_tool.Assert_colision>();
						center = scene.transform.Find( "assert_collision_center" )
							.GetComponent<tests_tool.Assert_colision>();
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator move_up_should_only_touch_collider_up()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.up;
						yield return new WaitForSeconds( 1 );
						up.assert_collision_enter( collider );
						down.assert_not_collision_enter();
						left.assert_not_collision_enter();
						right.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator move_down_should_only_touch_collider_down()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.down;
						yield return new WaitForSeconds( 1 );
						down.assert_collision_enter( collider );
						up.assert_not_collision_enter();
						left.assert_not_collision_enter();
						right.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator move_left_should_only_touch_collider_left()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.left;
						yield return new WaitForSeconds( 1 );
						left.assert_collision_enter( collider );
						up.assert_not_collision_enter();
						down.assert_not_collision_enter();
						right.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator move_right_should_only_touch_collider_right()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.right;
						yield return new WaitForSeconds( 1 );
						right.assert_collision_enter( collider );
						up.assert_not_collision_enter();
						down.assert_not_collision_enter();
						left.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator move_to_zero_should_stay_in_place()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector3.zero;
						yield return new WaitForSeconds( 1 );
						right.assert_not_collision_enter();
						up.assert_not_collision_enter();
						down.assert_not_collision_enter();
						left.assert_not_collision_enter();
						center.assert_not_collision_exit( collider );
					}
				}
			}
		}
	}
}
