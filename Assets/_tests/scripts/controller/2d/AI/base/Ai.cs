using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.ai;
using controller.controllers;

namespace ai
{

	public class Test_ai_when_intanciate
	{
		GameObject player, floor;

		[SetUp]
		public void Instanciate_scenary()
		{
			player =
				( GameObject )Resources.Load(
					"_prefab/tests/ai test_without_controller_assigned" );
			floor =
				( GameObject )Resources.Load(
					"_prefab/tests/floor_1" );
			player = helper.instantiate._( player );
			floor = helper.instantiate._( floor );
		}

		[TearDown]
		public void clean_scenary()
		{
			MonoBehaviour.DestroyImmediate( player );
			MonoBehaviour.DestroyImmediate( floor );
		}

		[UnityTest]
		public IEnumerator when_start_without_a_controller_asignated_should_find_the_controller_in_the_gameobject()
		{
			Ai ai = player.transform.GetComponent<Ai>();

			Controller_2d expected_controller =
				player.transform.GetComponent<Controller_2d>();

			yield return null;

			Assert.AreEqual( expected_controller, ai.controller );
		}
	}

}
