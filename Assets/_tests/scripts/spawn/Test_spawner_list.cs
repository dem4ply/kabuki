using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace spawner
{
	public class Test_spawner_list: helper.tests.Scene_test
	{
		invoker.Spawn_list spawn_list;

		public override string scene_dir
		{
			get {
				return "_test/scene/spawn/spawn_list";
			}
		}

		[SetUp]
		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			spawn_list = helper.game_object.Find._<invoker.Spawn_list>(
				scene, "spawn_list" ) ;
		}

		[UnityTest]
		public IEnumerator when_the_timer_finish_should_be_disabled()
		{
			yield return new WaitForSeconds( 3.1f );
			Assert.IsFalse( spawn_list.enabled );
		}

		[UnityTest]
		public IEnumerator should_invoke_5_obj()
		{
			yield return new WaitForSeconds( 2.6f );
			var objs = helper.game_object.Find.all( "player ball(Clone)" );
			Assert.AreEqual( 5, objs.Length );
		}

		[UnityTest]
		public IEnumerator should_invoke_10_objs_in_2_loops()
		{
			spawn_list.loops = 2;
			yield return new WaitForSeconds( 5.2f );
			var objs = helper.game_object.Find.all( "player ball(Clone)" );
			Assert.AreEqual( 10, objs.Length );
		}
	}
}
