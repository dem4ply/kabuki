using UnityEngine;
using NUnit.Framework;
using weapon.ammo;
using controller.controllers;

namespace singleton
{
	namespace object_pool
	{
		public class Test_ammo_pool : helper.tests.basic_test
		{
			[Test]
			public void should_create_the_container()
			{
				var ins = Ammo_pool.instance;
				var stuff = GameObject.Find(
					helper.consts.game_object_names.stuff );
				Assert.IsNotNull( stuff );
				var container = stuff.transform.Find( ins.container_name );
				Assert.IsNotNull( container );
			}

			[Test]
			public void should_instance_when_no_have_objects()
			{
				var bullet_1 = Resources.Load(
					"_test/prefab/bullets/slow" ) as GameObject;
				var bullet_2 = Resources.Load(
					"_test/prefab/bullets/fast" ) as GameObject;
				Assert.IsNotNull( bullet_1 );
				Assert.IsNotNull( bullet_2 );

				Ammo ammo_1 = Ammo.CreateInstance<Ammo>();
				ammo_1.prefab_bullet = bullet_1.GetComponent<
					Bullet_controller_3d>();
				Ammo ammo_2 = Ammo.CreateInstance<Ammo>();
				ammo_2.prefab_bullet = bullet_2.GetComponent<
					Bullet_controller_3d>();

				var ins = Ammo_pool.instance;
				Assert.IsNull( ins[ ammo_1 ] );
				Assert.IsNull( ins[ ammo_2 ] );

				var inst_bullet_1 = ins.pop( ammo_1 );
				Assert.IsNotNull( inst_bullet_1 );
			}

			[Test]
			public void should_add_the_same_object_in_the_same_stack()
			{
				var bullet_1 = Resources.Load(
					"_test/prefab/bullets/slow" ) as GameObject;
				Assert.IsNotNull( bullet_1 );

				Ammo ammo_1 = Ammo.CreateInstance<Ammo>();
				ammo_1.prefab_bullet = bullet_1.GetComponent<
					Bullet_controller_3d>();

				var ins = Ammo_pool.instance;
				Assert.IsNull( ins[ ammo_1 ] );

				var inst_bullet_1 = ins.pop( ammo_1 );
				var inst_bullet_2 = ins.pop( ammo_1 );
				ins.push( inst_bullet_1 );
				ins.push( inst_bullet_2 );
				Assert.IsNotNull( ins[ ammo_1 ] );
				Assert.AreEqual( 2, ins[ ammo_1 ].Count );
			}

			[Test]
			public void should_retrive_the_object_from_the_container()
			{
				var bullet_1 = Resources.Load(
					"_test/prefab/bullets/slow" ) as GameObject;
				Assert.IsNotNull( bullet_1 );

				Ammo ammo_1 = Ammo.CreateInstance<Ammo>();
				ammo_1.prefab_bullet = bullet_1.GetComponent<
					Bullet_controller_3d>();

				var ins = Ammo_pool.instance;
				Assert.IsNull( ins[ ammo_1 ] );

				var inst_bullet_1 = ins.pop( ammo_1 );
				var inst_bullet_2 = ins.pop( ammo_1 );
				ins.push( inst_bullet_1 );
				ins.push( inst_bullet_2 );
				Assert.IsNotNull( ins[ ammo_1 ] );
				Assert.AreEqual( 2, ins[ ammo_1 ].Count );
				ins.pop( ammo_1 );
				Assert.AreEqual( 1, ins[ ammo_1 ].Count );
				ins.pop( ammo_1 );
				Assert.AreEqual( 0, ins[ ammo_1 ].Count );
			}
		}
	}
}
