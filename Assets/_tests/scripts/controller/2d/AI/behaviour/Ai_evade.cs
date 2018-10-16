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

		public class Test_ai_evade
		{
			GameObject player, scene, damage;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_prefab/tests/ai_behavior/ai_evade" ) as GameObject;
				scene = helper.instantiate._( scene );
				player = scene.transform.Find( "player" ).gameObject;
				damage = scene.transform.Find( "moving_damage" ).gameObject;
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
				var old_distance =
					player.transform.position - damage.transform.position;
				yield return new WaitForSeconds( 1 );

				var current_distance =
					player.transform.position - damage.transform.position;
				Assert.Greater(
					current_distance.magnitude, old_distance.magnitude );
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
