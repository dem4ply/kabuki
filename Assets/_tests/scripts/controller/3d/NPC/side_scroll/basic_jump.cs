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
			public class Test_basic_jump
			{
					GameObject player, scene;
					tests_tool.Assert_colision assert_1, assert_2;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"side_scroll/basic_jump" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
						assert_1 = scene.transform.Find( "assert_collision_1" )
							.GetComponent<tests_tool.Assert_colision>();
						assert_2 = scene.transform.Find( "assert_collision_2" )
							.GetComponent<tests_tool.Assert_colision>();
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator when_jump_should_reach_both_collideer()
					{
						var motor = player.GetComponent<NPC_side_scroll_motor_3d>();
						yield return new WaitForSeconds( 0.1f );
						motor.jump();
						yield return new WaitForSeconds( 0.5f );
						assert_1.assert_collision_enter( motor );
						assert_2.assert_collision_enter( motor );
					}

					[UnityTest]
					public IEnumerator should_no_jump_in_middle_of_air()
					{
						var motor = player.GetComponent<NPC_side_scroll_motor_3d>();
						yield return new WaitForSeconds( 0.1f );
						motor.jump();
						yield return new WaitForSeconds( 0.2f );
						motor.stop_jump();
						yield return new WaitForSeconds( 0.3f );
						motor.jump();
						yield return new WaitForSeconds( 0.2f );
						motor.stop_jump();
						yield return new WaitForSeconds( 0.3f );
						Assert.IsTrue( motor.is_grounded );
					}
				}

			}
		}
	}
}
