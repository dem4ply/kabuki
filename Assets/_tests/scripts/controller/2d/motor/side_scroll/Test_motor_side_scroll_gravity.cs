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

			public class Test_motor_side_scroll_gravity
			{
				GameObject player, scene;

				[SetUp]
				public void Instanciate_scenary()
				{
					scene =
						Resources.Load(
							"_prefab/tests/chamber_is_grounded_1" ) as GameObject;
					scene = helper.instantiate._( scene );
					player = scene.transform.Find( "player" ).gameObject;
				}

				[TearDown]
				public void clean_scenary()
				{
					MonoBehaviour.DestroyImmediate( scene );
				}

				[UnityTest]
				public IEnumerator when_is_in_the_air_should_fall()
				{
					float started_y_point = player.transform.position.y;
					yield return new WaitForSeconds( 1 );
					float current_y_point = player.transform.position.y;
					Assert.Greater( started_y_point, current_y_point );
				}

				[UnityTest]
				public IEnumerator when_is_in_floor_should_no_fall()
				{
					NPC_side_scroll_motor_2d motor =
						player.GetComponent<NPC_side_scroll_motor_2d>();
					yield return new WaitForSeconds( 1 );
					Assert.IsTrue( motor.is_grounded );

					float started_y_point = player.transform.position.y;
					yield return new WaitForSeconds( 1 );
					float current_y_point = player.transform.position.y;
					Assert.AreEqual( started_y_point, current_y_point, 0.1f );
				}

				[UnityTest]
				public IEnumerator when_touch_the_floor_should_no_add_gravity()
				{
					NPC_side_scroll_motor_2d motor =
						player.GetComponent<NPC_side_scroll_motor_2d>();
					yield return new WaitForSeconds( 1 );
					Assert.IsTrue( motor.is_grounded );

					Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
					float current_y_velocity = rigidbody.velocity.y;
					Assert.LessOrEqual( current_y_velocity, 0.1f );
					yield return new WaitForSeconds( 1 );
					current_y_velocity = rigidbody.velocity.y;
					Assert.LessOrEqual( current_y_velocity, 0.1f );
				}
			}
		}
	}
}
