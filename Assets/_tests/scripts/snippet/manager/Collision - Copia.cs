using NUnit.Framework;
using manager;

namespace snippet
{
	namespace manager
	{
		class Test_collision
		{
			[Test]
			public void when_add_a_new_game_object_should_work()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				manager.add( info );
				Assert.IsNotNull( manager[ player ] );
				Assert.IsTrue( manager[ player, "test" ] );
			}

			[Test]
			public void when_add_two_obj_shold_work()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enamy = new UnityEngine.GameObject();
				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				Collision_info info_enemy = new Collision_info( "test", collision, enamy );
				manager.add( info );
				manager.add( info_enemy );

				Assert.IsNotNull( manager[ player ] );
				Assert.IsTrue( manager[ player, "test" ] );
				Assert.IsNotNull( manager[ enamy ] );
				Assert.IsTrue( manager[ enamy, "test" ] );
			}

			[Test]
			public void get_a_object_is_not_in_the_manager_should_return_null()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();

				Assert.IsNull( manager[ enemy ] );
				Assert.IsNull( manager[ player ] );
				Assert.IsFalse( manager[ enemy, "test" ] );
				Assert.IsFalse( manager[ player, "test" ] );

				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				manager.add( info );

				Assert.IsNull( manager[ enemy ] );
				Assert.IsNotNull( manager[ player ] );
				Assert.IsFalse( manager[ enemy, "test" ] );
				Assert.IsTrue( manager[ player, "test" ] );
			}

			[Test]
			public void get_a_event_when_no_exists_should_return_false()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();

				Assert.IsFalse( manager[ player, "test" ] );

				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				manager.add( info );

				Assert.IsTrue( manager[ player, "test" ] );
				Assert.IsFalse( manager[ player, "asdf" ] );
			}

			[Test]
			public void get_status_should_work()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();

				Assert.IsFalse( manager[ "test" ] );

				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				manager.add( info );

				Assert.IsTrue( manager[ "test" ] );
				Assert.IsFalse( manager[ "asdf" ] );
			}

			[Test]
			public void remove_status_should_work()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();

				Assert.IsFalse( manager[ "test" ] );

				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				manager.add( info );

				Assert.IsTrue( manager[ "test" ] );
				manager.remove( player );
				Assert.IsFalse( manager[ "test" ] );
			}

			[Test]
			public void after_remove_should_return_null_with_gameobject()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();

				Assert.IsFalse( manager[ "test" ] );

				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				manager.add( info );

				Assert.IsTrue( manager[ "test" ] );
				manager.remove( player );
				Assert.IsNull( manager[ player ] );
			}

			[Test]
			public void remove_twice_should_be_fine()
			{
				Collision_3d manager = new Collision_3d();
				UnityEngine.GameObject player = new UnityEngine.GameObject();

				Assert.IsFalse( manager[ "test" ] );

				UnityEngine.Collision collision = new UnityEngine.Collision();
				Collision_info info = new Collision_info( "test", collision, player );
				manager.add( info );

				Assert.IsTrue( manager[ "test" ] );
				manager.remove( player );
				Assert.IsNull( manager[ player ] );
				manager.remove( player );
				Assert.IsNull( manager[ player ] );
			}
		}
	}
}
