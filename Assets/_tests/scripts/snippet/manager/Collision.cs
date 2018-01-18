using NUnit.Framework;
using manager;

namespace test_snippet
{
	namespace manager
	{
		class Test_collision
		{
			[Test]
			public void when_add_a_new_game_object_should_work ()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				manager.add( player, "status", false );
			}

			[Test]
			public void add_two_obj_should_work()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", false );
				manager.add( enemy, "status", false );
			}


			[Test]
			public void when_add_by_second_time_should_work()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				manager.add( player, "status", false );
				manager.add( player, "status", true );
			}

			[Test]
			public void get_a_obj_that_is_not_in_the_manager_should_return_null()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				var result = manager.get( player );
				Assert.IsNull( result );
			}

			[Test]
			public void get_a_obj_that_is_in_the_manger_should_return_a_dict()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				manager.add( player, "status", false );
				var result = manager.get( player );
				Assert.IsNotNull( result );
			}

			[Test]
			public void get_a_obj_and_status_is_not_in_the_manager_should_be_false()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				bool result = manager.get( player, "status" );
				Assert.IsFalse( result );
			}

			[Test]
			public void get_a_obj_and_status_should_return_the_bool_expected()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				manager.add( player, "status", false );
				bool result = manager.get( player, "status" );
				Assert.IsFalse( result );

				manager.add( player, "status", true );
				result = manager.get( player, "status" );
				Assert.IsTrue( result );
			}

			[Test]
			public void get_obj_and_status_in_multiple_obj_should_work()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", false );
				manager.add( enemy, "status", true );
				bool result = manager.get( player, "status" );
				Assert.IsFalse( result );

				result = manager.get( enemy, "status" );
				Assert.IsTrue( result );

				manager.add( player, "status", true );
				result = manager.get( player, "status" );
				Assert.IsTrue( result );

				result = manager.get( enemy, "status" );
				Assert.IsTrue( result );
			}


			[Test]
			public void get_status_in_multiple_obj_case_1_should_be_false()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", false );
				manager.add( enemy, "status", false );
				bool result = manager.get( "status" );
				Assert.IsFalse( result );
			}

			[Test]
			public void get_status_in_multiple_obj_case_2_should_be_true()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", false );
				manager.add( enemy, "status", true );
				bool result = manager.get( "status" );
				Assert.IsTrue( result );
			}

			[Test]
			public void get_status_in_multiple_obj_case_3_should_be_true()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", true );
				manager.add( enemy, "status", false );
				bool result = manager.get( "status" );
				Assert.IsTrue( result );
			}

			[Test]
			public void get_status_in_multiple_obj_case_4_should_be_true()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", true );
				manager.add( enemy, "status", true );
				bool result = manager.get( "status" );
				Assert.IsTrue( result );
			}

			[Test]
			public void get_status_in_muliples_obj_and_losing_the_contacts_should_work()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", true );
				bool result = manager.get( "status" );
				Assert.IsTrue( result );

				manager.add( enemy, "status", true );
				result = manager.get( "status" );
				Assert.IsTrue( result );

				manager.add( player, "status", false );
				result = manager.get( "status" );
				Assert.IsTrue( result );

				manager.add( enemy, "status", false );
				result = manager.get( "status" );
				Assert.IsFalse( result );
			}

			[Test]
			public void when_is_remove_a_obj_the_get_should_be_false()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				manager.add( player, "status", true );
				bool result = manager.get( "status" );
				Assert.IsTrue( result );

				manager.remove( player );
				result = manager.get( "status" );
				Assert.IsFalse( result );
			}

			[Test]
			public void remove_with_multiple_objects_should_work()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				UnityEngine.GameObject enemy = new UnityEngine.GameObject();
				manager.add( player, "status", true );
				manager.add( enemy, "status", true );
				bool result = manager.get( "status" );
				Assert.IsTrue( result );

				manager.remove( enemy );
				result = manager.get( "status" );
				Assert.IsTrue( result );

				manager.remove( player );
				result = manager.get( "status" );
				Assert.IsFalse( result );
			}

			[Test]
			public void remove_twice_the_same_should_be_fine()
			{
				Collision manager = new Collision();
				UnityEngine.GameObject player = new UnityEngine.GameObject();
				manager.add( player, "status", true );
				manager.remove( player );
				manager.remove( player );
			}
		}
	}
}
