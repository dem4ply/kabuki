using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace spawner
{
	public class Test_spawner : helper.tests.Scene_test
	{
		Spawn_point spawn_point;

		public override string scene_dir
		{
			get {
				return "_prefab/tests/spawn/basic_spawn";
			}
		}

		[SetUp]
		public override void Instanciate_scenary()
		{
			base.Instanciate_scenary();
			spawn_point = helper.game_object.Find._<Spawn_point>(
				scene, "spawn_point" ) ;
		}

		[UnityTest]
		public IEnumerator when_spawn_should_return_the_new_game_object()
		{
			yield return new WaitForSeconds( 0.1f );
			GameObject obj = spawn_point.spawn();
			yield return new WaitForSeconds( 0.1f );
			Assert.IsNotNull( obj );
			MonoBehaviour.DestroyImmediate( obj );
		}

		[UnityTest]
		public IEnumerator the_new_object_should_be_in_scene()
		{
			yield return new WaitForSeconds( 0.1f );
			GameObject obj = spawn_point.spawn();
			GameObject obj_in_scenary = GameObject.Find( obj.name );
			yield return new WaitForSeconds( 0.1f );
			Assert.IsNotNull( obj_in_scenary );
			MonoBehaviour.DestroyImmediate( obj );
		}

		[UnityTest]
		public IEnumerator should_work_spawning_10_times()
		{
			for ( int i = 0; i < 10; ++i )
			{
				yield return new WaitForSeconds( 0.1f );
				GameObject obj = spawn_point.spawn();
				yield return new WaitForSeconds( 0.1f );
				MonoBehaviour.DestroyImmediate( obj );
			}
		}
	}
}
