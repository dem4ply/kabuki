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
					public class Test_orbit : helper.tests.Scene_test
					{
						GameObject player, collider;
						tests_tool.Assert_colision up, down, left, right;

						public override string scene_dir
						{
							get {
								return "_test/scene/controller/3d/ai/behavior/orbit";
							}
						}

						[SetUp]
						public override  void Instanciate_scenary()
						{
							base.Instanciate_scenary();
							player = scene.transform.Find( "player" ).gameObject;
							up = scene.transform.Find( "assert_collision_up" )
								.GetComponent<tests_tool.Assert_colision>();
							down = scene.transform.Find( "assert_collision_down" )
								.GetComponent<tests_tool.Assert_colision>();
							left = scene.transform.Find( "assert_collision_left" )
								.GetComponent<tests_tool.Assert_colision>();
							right = scene.transform.Find( "assert_collision_right" )
								.GetComponent<tests_tool.Assert_colision>();
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
