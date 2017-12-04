using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.ai;
using controller.controllers;

public class Test_ai_when_intanciate {

	[UnityTest]
	public IEnumerator when_start_wihout_a_controller_asignated_should_find_the_controller_in_the_gameobject() {
		var uni = Resources.Load( "_prefab/tests/ai test_without_controller_assigned" ) as GameObject;
		GameObject unitychan =
			(GameObject) Resources.Load(
				"_prefab/tests/ai test_without_controller_assigned" );
		GameObject floor =
			(GameObject) Resources.Load(
				"_prefab/tests/floor_1" );

		Debug.Log( unitychan );
		Debug.Log( unitychan.transform );
		Ai ai = unitychan.transform.GetComponent<Ai>();

		Controller_2d expected_controller =
			unitychan.transform.GetComponent<Controller_2d>();

		Assert.AreEqual( null, ai.controller );
		yield return null;

		Assert.AreEqual( expected_controller, ai.controller );
	}
}
