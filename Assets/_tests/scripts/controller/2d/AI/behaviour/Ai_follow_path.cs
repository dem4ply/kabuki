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
		}
	}
}
