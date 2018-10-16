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
		public class Test_ai_follow_path
		{
			GameObject player, scene;

			[SetUp]
			public void Instanciate_scenary()
			{
				scene =
					Resources.Load(
						"_prefab/tests/"
						+ "basic_chamber_for_path_follow" ) as GameObject;
				scene = helper.instantiate._( scene );
				player = scene.transform.Find( "ai_follow_path" ).gameObject;
			}

			[TearDown]
			public void clean_scenary()
			{
				MonoBehaviour.DestroyImmediate( scene );
			}

			[UnityTest]
			public IEnumerator agent_follow_path_and_die_in_the_end()
			{
				var hp = player.GetComponent<damage.motor.HP_motor>();

				Assert.AreEqual(
					hp.current_points, hp.total_of_points,
					"los puntos de vida del agente no estan llenos" );

				yield return new WaitForSeconds( 6.5f );

				Assert.IsTrue( hp.is_dead );
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
