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
					public class Test_look_at_gun
					{
						GameObject player, collider, scene;
						tests_tool.Assert_colision up, down, left, right, center;
						weapon.gun.Gun_base gun;

						[SetUp]
						public void Instanciate_scenary()
						{
							scene =
								Resources.Load(
									"_test/scene/controller/3d/" +
									"ai/behavior/orbital_gun" ) as GameObject;
							scene = helper.instantiate._( scene );
							player = scene.transform.Find( "player fly" ).gameObject;
							gun = helper.game_object.Find._<weapon.gun.Linear_gun>(
								scene, "linear_gun" );
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
							for ( int i = 0; i < 10; ++i )
							{
								var bullet = gun.shot();
								yield return new WaitForSeconds( 0.5f );
								center.assert_collision_enter( bullet );
							}
						}
					}
				}
			}
		}
	}
}
