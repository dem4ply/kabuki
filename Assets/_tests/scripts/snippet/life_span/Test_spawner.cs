using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace spawner
{
	public class Test_life_span : helper.tests.Scene_test
	{
		GameObject b1, b2;

		public override string scene_dir
		{
			get {
				return "_test/scene/helper/life_span/life_span";
			}
		}

		[SetUp]
		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			b1 = scene.transform.Find( "b1" ).gameObject;
			b2 = scene.transform.Find( "b2" ).gameObject;
		}

		[UnityTest]
		public IEnumerator should_died_using_the_timer()
		{
			yield return new WaitForSeconds( 1.1f );
			Assert.IsTrue( helper.game_object.comp.is_null( b1 ) );
		}

		[UnityTest]
		public IEnumerator should_be_destroy_the_timer()
		{
			yield return new WaitForSeconds( 1f );
			var timer = b2.GetComponent<helper.life.Life_timer>();
			Assert.IsNull( timer );
		}
	}
}
