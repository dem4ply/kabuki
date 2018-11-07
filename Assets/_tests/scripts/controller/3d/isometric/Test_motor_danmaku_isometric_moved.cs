using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.controllers.ai.tree_d;

namespace controller
{
	namespace motor
	{
		namespace tree_d
		{
			namespace isometric
			{

				public class Test_motor_danmaku_isometric_moved
				{
					GameObject player, collider, scene;
					tests_tool.Assert_colision up, down, left, right, floor;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"isometric/basic_move_danmaku" ) as GameObject;
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
						floor = scene.transform.Find( "floor_1" )
							.GetComponent<tests_tool.Assert_colision>();
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator should_have_disable_the_gravity()
					{
						yield return new WaitForSeconds( 0.1f );
						var r = player.GetComponent<Rigidbody>();
						Assert.False( r.useGravity );
						yield return new WaitForSeconds( 0.1f );
					}

					[UnityTest]
					public IEnumerator move_up_should_only_touch_collider_up()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.up;
						yield return new WaitForSeconds( 1 );
						up.assert_collision_enter( player );
						down.assert_not_collision_enter();
						left.assert_not_collision_enter();
						right.assert_not_collision_enter();
						floor.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator move_down_should_only_touch_collider_down()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.down;
						yield return new WaitForSeconds( 1 );
						down.assert_collision_enter( player );
						up.assert_not_collision_enter();
						left.assert_not_collision_enter();
						right.assert_not_collision_enter();
						floor.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator move_left_should_only_touch_collider_left()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.left;
						yield return new WaitForSeconds( 1 );
						left.assert_collision_enter( player );
						up.assert_not_collision_enter();
						down.assert_not_collision_enter();
						right.assert_not_collision_enter();
						floor.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator move_right_should_only_touch_collider_right()
					{
						var ai = player.GetComponent<AI_walk_3d>();
						ai.desire_direction = Vector2.right;
						yield return new WaitForSeconds( 1 );
						right.assert_collision_enter( player );
						up.assert_not_collision_enter();
						down.assert_not_collision_enter();
						left.assert_not_collision_enter();
						floor.assert_not_collision_enter();
					}
				}
			}
		}
	}
}
