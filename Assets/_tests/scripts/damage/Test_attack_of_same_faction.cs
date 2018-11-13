using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace damage
{
	public class Test_attack_of_same_faction : helper.tests.Scene_test
	{
		public Transform enemy_1, enemy_2;
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
		}

		[UnityTest]
		public IEnumerator when_spawn_should_return_the_new_game_object()
		{
			yield return new WaitForSeconds( 2.1f );
			Assert.IsFalse( helper.game_object.comp.is_null( enemy_1 ) );
			Assert.IsFalse( helper.game_object.comp.is_null( enemy_2 ) );
		}
	}
}
