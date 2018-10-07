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
			public class Test_is_walled
			{
					GameObject player, scene;
					tests_tool.Assert_colision left, right;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"side_scroll/basic_wall_platform_bender" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
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
						motor.max_speed = 30;
						yield return new WaitForSeconds( 1.0f );
						Assert.IsTrue( motor.is_walled );
						Assert.IsFalse( motor.is_not_walled );
					}
				}

			}
		}
	}
}
