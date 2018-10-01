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
			namespace side_scroll
			{
			public class Test_basic_move
			{
					GameObject player, scene;
					tests_tool.Assert_colision left, right;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/side_scroll/basic_move" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
						left = scene.transform.Find( "assert_collision_left" )
							.GetComponent<tests_tool.Assert_colision>();
						right = scene.transform.Find( "assert_collision_right" )
							.GetComponent<tests_tool.Assert_colision>();
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator when_the_direction_is_left_shold_touch_left()
					{
						var ai = player.GetComponent<ai.Ai_walk>();
						ai.desire_direction = Vector2.left;
						yield return new WaitForSeconds( 1 );
						left.assert_collision_enter( ai.gameObject );
						right.assert_not_collision_enter();
					}

					[UnityTest]
					public IEnumerator when_the_direction_is_right_should_touch_right()
					{
						var ai = player.GetComponent<ai.Ai_walk>();
						ai.desire_direction = Vector2.right;
						yield return new WaitForSeconds( 1 );
						right.assert_collision_enter( ai.gameObject );
						left.assert_not_collision_enter();
					}
				}

			}
		}
	}
}
