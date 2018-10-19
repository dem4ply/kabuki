using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor.platform;

namespace controller
{
	namespace motor
	{
		namespace tree_d
		{
			namespace platform
			{
				public class Test_summon
				{
					GameObject platform, scene, player;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"platform/basic_platform" ) as GameObject;
						scene = helper.instantiate._( scene );
						platform = scene.transform.Find( "platform_motor" ).gameObject;
						player = Resources.Load(
							"_prefab/player_side_scroll" ) as GameObject;
						player = helper.instantiate._( player );
						player.transform.position = new Vector3(
							platform.transform.position.x,
							platform.transform.position.y + 3,
							platform.transform.position.z );
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator should_create_a_new_gameobject()
					{
						var motor = platform.GetComponent<Platform_motor_base>();
						var new_platform = motor.summon();
						Rigidbody rigidbody = player.GetComponent<Rigidbody>();
						yield return new WaitForSeconds( 1.5f );
						Assert.GreaterOrEqual( rigidbody.velocity.y, -0.1f );
						MonoBehaviour.DestroyImmediate( new_platform );
					}

					[UnityTest]
					public IEnumerator should_spawn_in_the_same_postion_that_motor()
					{
						var motor = platform.GetComponent<Platform_motor_base>();
						var new_platform = motor.summon();
						yield return new WaitForSeconds( 0.1f );
						Assert.AreEqual(
							new_platform.transform.position,
							motor.transform.position );
						MonoBehaviour.DestroyImmediate( new_platform );
					}
				}
			}
		}
	}
}
