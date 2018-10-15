using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using weapon.bullet;
using weapon.weapon;

namespace spawner
{
	public class Test_spawner
	{
		GameObject scene;
		Spawn_point spawn_point;

		[SetUp]
		public void Instanciate_scenary()
		{
			scene =
				Resources.Load(
					"_prefab/tests/spawn/basic_spawn" ) as GameObject;
			scene = helper.instantiate._( scene );
			spawn_point = helper.game_object.Find._<Spawn_point>(
				scene, "spawn_point" ) ;
		}

		[TearDown]
		public void clean_scenary()
		{
			MonoBehaviour.DestroyImmediate( scene );
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
