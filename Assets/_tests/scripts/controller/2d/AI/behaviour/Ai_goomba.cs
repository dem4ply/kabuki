using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.ai;

public class Test_ai_goomba
{
	GameObject player, scene;

	[SetUp]
	public void Instanciate_scenary()
	{
		scene =
			Resources.Load( "_prefab/tests/goomba_chamber_1" ) as GameObject;
		scene = helper.instantiate._( scene );
		player = scene.transform.Find( "ai_goomba" ).gameObject;
	}

	[TearDown]
	public void clean_scenary()
	{
		MonoBehaviour.DestroyImmediate( scene );
	}

	[UnityTest]
	public IEnumerator walk_to_the_left_when_collide_should_walk_to_the_right()
	{
		Ai_goomba ai = player.GetComponent<Ai_goomba>();
		ai.desire_direction = Vector2.left;
		Vector2 start_position = player.transform.position;
		yield return new WaitForSeconds( 1 );
		Assert.Greater( ai.desire_direction.x, 0 );
	}

	[UnityTest]
	public IEnumerator walk_to_the_left_when_collide_should_walk_to_the_left()
	{
		Ai_goomba ai = player.GetComponent<Ai_goomba>();
		ai.desire_direction = Vector2.right;
		Vector2 start_position = player.transform.position;
		yield return new WaitForSeconds( 1 );
		Assert.Less( ai.desire_direction.x, 0 );
	}
}
