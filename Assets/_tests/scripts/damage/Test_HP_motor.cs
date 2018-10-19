using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;
using damage.motor;

namespace damage
{
	public class Test_HP_motor
	{
		GameObject player, scene;

		[SetUp]
		public void Instanciate_scenary()
		{
			scene =
				Resources.Load( "_prefab/tests/basic_damage_chamber" ) as GameObject;
			scene = helper.instantiate._( scene );
			player = scene.transform.Find( "player" ).gameObject;
		}

		[TearDown]
		public void clean_scenary()
		{
			MonoBehaviour.DestroyImmediate( scene );
		}

		[UnityTest]
		public IEnumerator when_HP_motor_touch_a_damage_trigger_should_loss_hp()
		{
			player.GetComponent<controller.ai.Ai_walk>();
			var hp = player.GetComponent<HP_motor>();
			int start_hp = hp.current_points;
			yield return new WaitForSeconds( 1 );
			Assert.Less( hp.current_points, start_hp );
		}

		[UnityTest]
		public IEnumerator when_hp_is_0_or_less_the_motor_2d_should_be_dead()
		{
			player.GetComponent<controller.ai.Ai_walk>();
			var motor = player.GetComponent<Motor_2d>();
			var hp = player.GetComponent<HP_motor>();

			int start_hp = hp.current_points;
			Assert.Greater( start_hp, 0 );
			Assert.IsTrue( motor.is_not_dead );
			yield return new WaitForSeconds( 1 );
			Assert.LessOrEqual( hp.current_points, 0 );
			Assert.IsTrue( motor.is_dead );
		}
	}
}
