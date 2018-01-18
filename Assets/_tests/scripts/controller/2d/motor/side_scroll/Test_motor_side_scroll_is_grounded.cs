using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

public class Test_motor_side_scroll_is_gounded
{
	GameObject player, scene;

	[SetUp]
	public void Instanciate_scenary()
	{
		scene =
			Resources.Load( "_prefab/tests/chamber_is_grounded_1" ) as GameObject;
		scene = helper.instantiate._( scene );
		player = scene.transform.Find( "player" ).gameObject;
	}

	[TearDown]
	public void clean_scenary()
	{
		MonoBehaviour.DestroyImmediate( scene );
	}

	[UnityTest]
	public IEnumerator if_the_player_is_in_air_should_no_be_grounded()
	{
		NPC_side_scroll_motor_2d motor =
			player.GetComponent<NPC_side_scroll_motor_2d>();
		Assert.IsFalse( motor.is_grounded );
		yield return null;
	}

	[UnityTest]
	public IEnumerator when_touch_the_floor_shoud_be_grounded()
	{
		NPC_side_scroll_motor_2d motor =
			player.GetComponent<NPC_side_scroll_motor_2d>();
		yield return new WaitForSeconds( 1 );
		Assert.IsTrue( motor.is_grounded );
		yield return null;
	}
}