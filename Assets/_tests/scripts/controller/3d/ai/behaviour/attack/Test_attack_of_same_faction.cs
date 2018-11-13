using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace ai
{
	namespace tree_d
	{
		namespace behavior
		{
			public class Test_attack_timer : helper.tests.Scene_test
			{
				public Transform enemy_1, enemy_2;
				tests_tool.Assert_colision center;
				public override string scene_dir
				{
					get {
						return
							"_test/scene/controller/3d/ai/behavior/attack/" +
							"attack_2_enemies";
					}
				}

				public override void Instanciate_scenary()
				{
					base.Instanciate_scenary();
					enemy_1 = scene.transform.Find( "enemy 1" );
					enemy_2 = scene.transform.Find( "enemy 2" );
					center = helper.game_object.Find._<tests_tool.Assert_colision>(
						scene, "center" );
				}

				[UnityTest]
				public IEnumerator both_enamies_should_shot_in_the_center()
				{
					yield return new WaitForSeconds( 2.1f );
					center.assert_collision_enter();
				}
			}
		}
	}
}