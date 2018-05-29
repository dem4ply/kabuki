using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace controller
{

	public class Test_motor_2d
	{
		GameObject player, scene;

		[SetUp]
		public void Instanciate_scenary()
		{
			scene =
				Resources.Load(
					"_prefab/tests/chamber_test_jump_1" ) as GameObject;
			scene = helper.instantiate._( scene );
			player = scene.transform.Find( "player" ).gameObject;
		}

		[TearDown]
		public void clean_scenary()
		{
			MonoBehaviour.DestroyImmediate( scene );
		}

		[UnityTest]
		public IEnumerator motor_should_put_the_gravity_scale_in_0_when_start()
		{
			Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
			yield return null;
			Assert.AreEqual( 0f, rigidbody.gravityScale );
		}
	}
}
