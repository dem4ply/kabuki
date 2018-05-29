using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace controller
{
	namespace motor
	{
		namespace side_scroll
		{

			public class Test_motor_side_scroll_is_walled
			{
				GameObject player_left, player_right, scene;

				[SetUp]
				public void Instanciate_scenary()
				{
					scene =
						Resources.Load(
							"_prefab/tests/chamber_is_walled" ) as GameObject;
					scene = helper.instantiate._( scene );
					player_left = scene.transform.Find(
						"player_walk_left" ).gameObject;
					player_right = scene.transform.Find(
						"player_walk_right" ).gameObject;
				}

				[TearDown]
				public void clean_scenary()
				{
					MonoBehaviour.DestroyImmediate( scene );
				}

				[UnityTest]
				public IEnumerator touch_left_wall_should_player_be_walled()
				{
					NPC_side_scroll_motor_2d motor =
						player_left.GetComponent<NPC_side_scroll_motor_2d>();
					Assert.IsFalse( motor.is_walled );
					Assert.IsTrue( motor.is_not_walled );
					yield return new WaitForSeconds( 1 );
					Assert.IsTrue( motor.is_walled );
					Assert.IsFalse( motor.is_not_walled );
				}

				[UnityTest]
				public IEnumerator touch_right_wall_should_player_be_walled()
				{
					NPC_side_scroll_motor_2d motor =
						player_right.GetComponent<NPC_side_scroll_motor_2d>();
					Assert.IsFalse( motor.is_walled );
					Assert.IsTrue( motor.is_not_walled );
					yield return new WaitForSeconds( 1 );
					Assert.IsTrue( motor.is_walled );
					Assert.IsFalse( motor.is_not_walled );
				}

				[UnityTest]
				public IEnumerator touch_left_wall_should_player_be_walled_left()
				{
					NPC_side_scroll_motor_2d motor =
						player_left.GetComponent<NPC_side_scroll_motor_2d>();
					Assert.IsFalse( motor.is_walled );
					Assert.IsTrue( motor.is_not_walled );
					Assert.IsTrue( motor.no_is_walled_left );
					Assert.IsTrue( motor.no_is_walled_right );
					yield return new WaitForSeconds( 1 );
					Assert.IsTrue( motor.is_walled_left );
					Assert.IsFalse( motor.is_walled_right );
				}

				[UnityTest]
				public IEnumerator touch_left_wall_should_player_be_walled_right()
				{
					NPC_side_scroll_motor_2d motor =
						player_right.GetComponent<NPC_side_scroll_motor_2d>();
					Assert.IsFalse( motor.is_walled );
					Assert.IsTrue( motor.is_not_walled );
					Assert.IsTrue( motor.no_is_walled_left );
					Assert.IsTrue( motor.no_is_walled_right );
					yield return new WaitForSeconds( 1 );
					Assert.IsTrue( motor.is_walled_right );
					Assert.IsFalse( motor.is_walled_left );
				}

			}
		}
	}
}
