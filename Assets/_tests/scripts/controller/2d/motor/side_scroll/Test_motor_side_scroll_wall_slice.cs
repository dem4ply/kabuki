using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

public class Test_motor_side_scroll_wall_slice
{
	GameObject player, player_left, player_right, scene;

	[SetUp]
	public void Instanciate_scenary()
	{
		scene =
			Resources.Load( "_prefab/tests/chamber_wall_slice" ) as GameObject;
		scene = helper.instantiate._( scene );
		player_left = scene.transform.Find( "player_walk_left" ).gameObject;
		player = scene.transform.Find( "player" ).gameObject;
		player_right = scene.transform.Find( "player_walk_right" ).gameObject;
	}

	[TearDown]
	public void clean_scenary()
	{
		MonoBehaviour.DestroyImmediate( scene );
	}

	[UnityTest]
	public IEnumerator left_slice_should_be_more_slow_that_normal_fall()
	{
		Rigidbody2D rigidbody_left = player_left.GetComponent<Rigidbody2D>();
		Rigidbody2D rigidbody_normal = player.GetComponent<Rigidbody2D>();
		yield return new WaitForSeconds( 0.3f );

		Assert.Less(
			Mathf.Abs( rigidbody_left.velocity.y ),
			Mathf.Abs( rigidbody_normal.velocity.y ) );
	}

	[UnityTest]
	public IEnumerator right_slice_should_be_more_slow_that_normal_fall()
	{
		Rigidbody2D rigidbody_right = player_right.GetComponent<Rigidbody2D>();
		Rigidbody2D rigidbody_normal = player.GetComponent<Rigidbody2D>();
		yield return new WaitForSeconds( 0.3f );

		Assert.Less(
			Mathf.Abs( rigidbody_right.velocity.y ),
			Mathf.Abs( rigidbody_normal.velocity.y ) );
	}

	[UnityTest]
	public IEnumerator left_and_right_slice_should_have_same_speed()
	{
		Rigidbody2D rigidbody_right = player_right.GetComponent<Rigidbody2D>();
		Rigidbody2D rigidbody_left = player_left.GetComponent<Rigidbody2D>();
		yield return new WaitForSeconds( 0.3f );

		Assert.AreEqual(
			rigidbody_right.velocity.y, rigidbody_left.velocity.y, 0.01f );
	}
}
