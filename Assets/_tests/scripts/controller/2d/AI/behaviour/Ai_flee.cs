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

		public class Test_ai_flee
		{
			GameObject player, scene, damage;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_prefab/tests/ai_flee_basic_chamber" ) as GameObject;
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
			public IEnumerator agent_should_be_more_far_of_the_target()
			{
				var ai = player.GetComponent<controller.ai.Ai_flee>();
				var motor = player.GetComponent<controller.motor.Motor_2d>();

				var old_distance =
					player.transform.position - damage.transform.position;
				yield return new WaitForSeconds( 1 );

				var current_distance =
					player.transform.position - damage.transform.position;
				Assert.Greater(
					current_distance.magnitude, old_distance.magnitude );
			}

			[UnityTest]
			public IEnumerator should_no_change_direction_when_target_no_move()
			{
				var ai = player.GetComponent<controller.ai.Ai_flee>();
				var motor = player.GetComponent<controller.motor.Motor_2d>();

				yield return new WaitForSeconds( 1 );
				var old_flee_vector = ai.flee( damage );

				yield return new WaitForSeconds( 1 );
				var current_flee_vector = ai.flee( damage );

				old_flee_vector.Normalize();
				current_flee_vector.Normalize();
				Assert.AreEqual( old_flee_vector.x, current_flee_vector.x, 0.01f );
				Assert.AreEqual( old_flee_vector.y, current_flee_vector.y, 0.01f );
				Assert.AreEqual( old_flee_vector.z, current_flee_vector.z, 0.01f );

			}
		}
	}
}
