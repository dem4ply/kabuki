using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;
using damage.motor;

namespace damage
{
	namespace behavior
	{
		public class Test_one_hit_destroy : helper.tests.Scene_test
		{
			GameObject damage;

			[SetUp]
			public override void Instanciate_scenary()
			{
				scene =
					Resources.Load( "_test/scene/damage/damage_big" ) as GameObject;
				scene = helper.instantiate._( scene );
				damage = scene.transform.Find( "damage" ).gameObject;
			}

			[UnityTest]
			public IEnumerator when_hit_a_hp_motor_shoud_be_destroy()
			{
				yield return new WaitForSeconds( 1 );
				Assert.IsTrue( helper.game_object.comp.is_null( damage ) );
				/*
				var hp_1 = player.GetComponent<HP_motor>();
				var hp_2 = enemy_1.GetComponent<HP_motor>();
				var hp_3 = enemy_2.GetComponent<HP_motor>();
				var hp_4 = enemy_3.GetComponent<HP_motor>();
				var hp_5 = enemy_4.GetComponent<HP_motor>();

				bool[] deads = {
					hp_1.is_dead, hp_2.is_dead, hp_3.is_dead, hp_4.is_dead,
					hp_5.is_dead };

				int dead_amount = 0;
				foreach ( bool is_dead in deads )
					if ( is_dead )
						++dead_amount;

				Assert.AreEqual( 1, dead_amount );
				*/
			}
		}
	}
}
