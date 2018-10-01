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
			public class Test_is_grounded
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
						player.transform.localPosition = new Vector3(
							player.transform.localPosition.x, 2f,
							player.transform.localPosition.z );
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator when_is_in_air_should_be_no_grounded()
					{
						var motor = player.GetComponent<NPC_side_scroll_motor_3d>();
						yield return new WaitForSeconds( 0.1f );
						Assert.IsTrue( motor.is_not_grounded );
					}

					[UnityTest]
					public IEnumerator when_touch_the_floor_should_be_grounded()
					{
						var motor = player.GetComponent<NPC_side_scroll_motor_3d>();
						yield return new WaitForSeconds( 1f );
						Assert.IsTrue( motor.is_grounded );
					}

					[UnityTest]
					public IEnumerator when_exit_the_collition_shoud_be_no_grouned()
					{
						var motor = player.GetComponent<NPC_side_scroll_motor_3d>();
						yield return new WaitForSeconds( 1f );
						Assert.IsTrue( motor.is_grounded );
						player.transform.localPosition = new Vector3(
							player.transform.localPosition.x, 5f,
							player.transform.localPosition.z );
						yield return new WaitForSeconds( 0.3f );
						Assert.IsTrue( motor.is_not_grounded );
					}

				}

			}
		}
	}
}
