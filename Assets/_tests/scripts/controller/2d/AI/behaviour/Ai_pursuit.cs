using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.ai;
using controller.controllers;

namespace ai
{
	namespace behavior
	{

		public class Test_ai_pursuit
		{
			GameObject player, scene, damage;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_prefab/tests/ai_behavior/ai_pursuit" ) as GameObject;
				scene = helper.instantiate._( scene );
				player = scene.transform.Find( "player" ).gameObject;
				damage = scene.transform.Find( "moving_damage" ).gameObject;
			}

			[TearDown]
			public void clean_scenary()
			{
				MonoBehaviour.DestroyImmediate( scene );
			}

			[UnityTest]
			public IEnumerator agent_chase_the_damage_and_die()
			{
				var motor = player.GetComponent<controller.motor.Motor_2d>();
				var hp = player.GetComponent<damage.motor.HP_motor>();

				int start_hp = hp.current_points;
				Assert.Greater( start_hp, 0 );
				Assert.IsTrue( motor.is_not_dead );
				yield return new WaitForSeconds( 2 );
				Assert.LessOrEqual( hp.current_points, 0 );
				Assert.IsTrue( motor.is_dead );
			}
		}
	}
}