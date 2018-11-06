using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor.platform;

namespace controller
{
	namespace motor
	{
		namespace behavior
		{
			namespace dead
			{
				public class Test_explotion_enemy
				{
					GameObject scene, player;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"motor/behavior/dead/explotion enemy" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator should_destroy_the_game_object()
					{
						var motor = player.GetComponent<Motor_base>();
						Assert.IsFalse( motor.is_dead );
						motor.died();
						Assert.IsTrue( motor.is_dead );
						yield return new WaitForSeconds( 1f );
						Assert.IsTrue( helper.game_object.comp.is_null( motor ) );
					}
				}
			}
		}
	}
}
