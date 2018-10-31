using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;
using damage.motor;

namespace damage
{
	public class Test_damage
	{
		GameObject player, enemy_1, enemy_2, enemy_3, enemy_4, scene, damage;

		[SetUp]
		public void Instanciate_scenary()
		{
			scene =
				Resources.Load( "_test/scene/damage/damage_simple" ) as GameObject;
			scene = helper.instantiate._( scene );
			player = scene.transform.Find( "player fly" ).gameObject;
			enemy_1 = scene.transform.Find( "test_enemy" ).gameObject;
			enemy_2 = scene.transform.Find( "test_enemy (1)" ).gameObject;
			enemy_3 = scene.transform.Find( "test_enemy (2)" ).gameObject;
			enemy_4 = scene.transform.Find( "test_enemy (3)" ).gameObject;
			damage = scene.transform.Find( "damage" ).gameObject;
		}

		[TearDown]
		public void clean_scenary()
		{
			MonoBehaviour.DestroyImmediate( scene );
		}

		[UnityTest]
		public IEnumerator should_save_the_hp_motor_in_taken_y()
		{
			yield return new WaitForSeconds( 0.3f );
			var hp_1 = player.GetComponent<HP_motor>();
			var hp_2 = enemy_1.GetComponent<HP_motor>();
			var hp_3 = enemy_2.GetComponent<HP_motor>();
			var hp_4 = enemy_3.GetComponent<HP_motor>();
			var hp_5 = enemy_4.GetComponent<HP_motor>();
			var d = damage.GetComponent<Damage>();

			Assert.IsTrue( d.taken_by.Contains( hp_1 ) );
			Assert.IsTrue( d.taken_by.Contains( hp_2 ) );
			Assert.IsTrue( d.taken_by.Contains( hp_3 ) );
			Assert.IsFalse( d.taken_by.Contains( hp_4 ) );
			Assert.IsFalse( d.taken_by.Contains( hp_5 ) );
		}
	}
}
