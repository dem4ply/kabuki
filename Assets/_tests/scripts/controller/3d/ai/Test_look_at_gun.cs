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
					public class Test_look_at_gun : helper.tests.Scene_test
					{
						GameObject collider;
						tests_tool.Assert_colision center;
						weapon.gun.Gun_base gun;

						public override string scene_dir
						{
							get {
								return
									"_test/scene/controller/3d/" +
									"ai/behavior/orbital_gun";
							}
						}

						public override void Instanciate_scenary()
						{
							base.Instanciate_scenary();
							gun = helper.game_object.Find._<weapon.gun.Linear_gun>(
								scene, "linear_gun" );
							center = scene.transform.Find( "assert_collision_center" )
								.GetComponent<tests_tool.Assert_colision>();
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
