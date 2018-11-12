using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.ai;
using controller.controllers;
using tests_tool;

namespace ai
{
	namespace tree_d
	{
		namespace behavior
		{
			public class Test_sin_down : helper.tests.Scene_test
			{
				GameObject player;
				Assert_colision no_touch_1, no_touch_2;
				Assert_colision touch_1, touch_2, touch_3;

				public override string scene_dir
				{
					get {
						return
							"_test/scene/controller/3d/ai/behavior/math_pattern/"
							+ "sin_walk_down";
					}
				}

				[SetUp]
				public override void Instanciate_scenary()
				{
					base.Instanciate_scenary();
					player = scene.transform.Find( "player" ).gameObject;

					no_touch_1 = helper.game_object.Find._<Assert_colision>(
						scene, "no_touch_1" );
					no_touch_2 = helper.game_object.Find._<Assert_colision>(
						scene, "no_touch_2" );

					touch_1 = helper.game_object.Find._<Assert_colision>(
						scene, "touch_1" );
					touch_2 = helper.game_object.Find._<Assert_colision>(
						scene, "touch_2" );
					touch_3 = helper.game_object.Find._<Assert_colision>(
						scene, "touch_3" );
				}

				[UnityTest]
				public IEnumerator agent_shold_touch_all_colliders()
				{
					yield return new WaitForSeconds( 4 );
					touch_1.assert_collision_enter( player );
					touch_2.assert_collision_enter( player );
					touch_3.assert_collision_enter( player );

					no_touch_1.assert_not_collision_enter( player );
					no_touch_2.assert_not_collision_enter( player );
					yield return new WaitForSeconds( 0.1f );
				}
			}
		}
	}
}
