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
		public class Test_ai_seek
		{
			GameObject player, scene, damage;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_prefab/tests/ai_seek_basic_chamber" ) as GameObject;
				scene = helper.instantiate._( scene );
				player = scene.transform.Find( "player" ).gameObject;
				damage = scene.transform.Find( "damage" ).gameObject;
				damage.transform.position = new Vector3(
					Random.Range( -3f, 3f ), Random.Range( -3f, 3f ) );
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
				yield return new WaitForSeconds( 1 );
				Assert.LessOrEqual( hp.current_points, 0 );
				Assert.IsTrue( motor.is_dead );
			}

			[UnityTest]
			public IEnumerator if_the_target_is_null_should_no_move()
			{
				yield return new WaitForSeconds( 0.1f );
				var ai = player.GetComponent<controller.ai.Ai_steering_behavior>();
				ai.target = null;
				yield return new WaitForSeconds( 1f );
				var old_pos = player.transform.position;
				yield return new WaitForSeconds( 0.2f );
				var new_pos = player.transform.position;
				Assert.AreEqual( old_pos, new_pos );
			}
		}
	}
}
