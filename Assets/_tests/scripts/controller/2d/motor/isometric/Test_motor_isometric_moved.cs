using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace controller
{
	namespace motor
	{
		namespace isometric
		{

			public class Test_motor_isometric_moved
			{
				GameObject player, scene;

				[SetUp]
				public void Instanciate_scenary()
				{
					scene =
						Resources.Load(
							"_prefab/tests/"
							+ "basic_test_for_isometric_NPC" ) as GameObject;
					scene = helper.instantiate._( scene );
					player = scene.transform.Find( "player" ).gameObject;
				}

				[TearDown]
				public void clean_scenary()
				{
					MonoBehaviour.DestroyImmediate( scene );
				}

				[UnityTest]
				public IEnumerator if_move_to_up_should_only_increment_the_y()
				{
					var ai = player.GetComponent<controller.ai.Ai_walk>();
					ai.transform.position = Vector2.zero;
					ai.desire_direction = Vector2.up;
					yield return new WaitForSeconds( 1 );
					Assert.Less( player.transform.position.x, 0.1f );
					Assert.Greater( player.transform.position.y, 0 );
				}

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
			}
		}
	}
}
