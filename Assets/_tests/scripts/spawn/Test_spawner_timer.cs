using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace spawner
{
	public class Test_spawner_timer : helper.tests.Scene_test
	{
		public override string scene_dir
		{
			get {
				return "_test/scene/spawn/spawn_timer";
			}
		}

		[SetUp]
		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
		}

		[UnityTest]
		public IEnumerator the_timer_should_create_a_object()
		{
			yield return new WaitForSeconds( 0.6f );
			var a = GameObject.Find( "player ball(Clone)" );
			Assert.IsNotNull( a );
			MonoBehaviour.Destroy( a );
			yield return new WaitForSeconds( 0.6f );
			a = GameObject.Find( "player ball(Clone)" );
			Assert.IsNotNull( a );
			MonoBehaviour.Destroy( a );
		}
	}
}
