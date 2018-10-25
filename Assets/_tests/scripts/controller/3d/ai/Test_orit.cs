using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace behavior
				{
					public class Test_orit
					{
						GameObject player, collider, scene;
						tests_tool.Assert_colision up, down, left, right, center;

						[SetUp]
						public void Instanciate_scenary()
						{
							scene =
								Resources.Load(
									"_test/scene/controller/3d/" +
									"ai/behavior/orbit" ) as GameObject;
							scene = helper.instantiate._( scene );
							player = scene.transform.Find( "player" ).gameObject;
							up = scene.transform.Find( "assert_collision_up" )
								.GetComponent<tests_tool.Assert_colision>();
							down = scene.transform.Find( "assert_collision_down" )
								.GetComponent<tests_tool.Assert_colision>();
							left = scene.transform.Find( "assert_collision_left" )
								.GetComponent<tests_tool.Assert_colision>();
							right = scene.transform.Find( "assert_collision_right" )
								.GetComponent<tests_tool.Assert_colision>();
							center = scene.transform.Find( "assert_collision_center" )
								.GetComponent<tests_tool.Assert_colision>();
						}

						[TearDown]
						public void clean_scenary()
						{
							MonoBehaviour.DestroyImmediate( scene );
						}

						[UnityTest]
						public IEnumerator when_orbit_should_touch_all_colliders()
						{
							yield return new WaitForSeconds( 4 );
							up.assert_collision_enter( player );
							down.assert_collision_enter( player );
							left.assert_collision_enter( player );
							right.assert_collision_enter( player );
						}
					}
				}
			}
		}
	}
}
