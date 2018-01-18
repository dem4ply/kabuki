using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

public class Test_motor_side_scroll_jump
{
	GameObject player, scene;

	[SetUp]
	public void Instanciate_scenary()
	{
		scene =
			Resources.Load( "_prefab/tests/chamber_test_jump_1" ) as GameObject;
		scene = helper.instantiate._( scene );
		player = scene.transform.Find( "player" ).gameObject;
	}

	[TearDown]
	public void clean_scenary()
	{
		MonoBehaviour.DestroyImmediate( scene );
	}

	[UnityTest]
	public IEnumerator can_jump_if_the_player_is_grounded()
	{
		yield return new WaitForSeconds( 1 );
		NPC_side_scroll_motor_2d motor =
			player.GetComponent<NPC_side_scroll_motor_2d>();
		Assert.IsTrue( motor.is_grounded );
		float y_position_in_the_floor = motor.transform.position.y;
		motor.jump();
		yield return new WaitForSeconds( 0.1f );
		Assert.Greater( motor.transform.position.y, y_position_in_the_floor );
		yield return null;
	}

	[UnityTest]
	public IEnumerator after_the_jump_is_grounded_should_be_false()
	{
		yield return new WaitForSeconds( 1 );
		NPC_side_scroll_motor_2d motor =
			player.GetComponent<NPC_side_scroll_motor_2d>();
		Assert.IsTrue( motor.is_grounded );
		float y_position_in_the_floor = motor.transform.position.y;
		motor.jump();
		yield return new WaitForSeconds( 0.1f );
		Assert.IsFalse( motor.is_grounded );
		yield return null;
	}
}
