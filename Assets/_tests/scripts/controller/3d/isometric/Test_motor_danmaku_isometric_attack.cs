using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.isometric.motor;

namespace controller
{
	namespace motor
	{
		namespace tree_d
		{
			namespace isometric
			{

				public class Test_motor_danmaku_isometric_attack
				{
					GameObject player, collider, scene;
					tests_tool.Assert_colision up, down, left, right, floor;
					NPC_danmaku_isometric_motor_3d motor;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"isometric/basic_move_danmaku" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
						collider = helper.game_object.Find._( player, "Sphere" );
						up = scene.transform.Find( "assert_collision_up" )
							.GetComponent<tests_tool.Assert_colision>();
						down = scene.transform.Find( "assert_collision_down" )
							.GetComponent<tests_tool.Assert_colision>();
						left = scene.transform.Find( "assert_collision_left" )
							.GetComponent<tests_tool.Assert_colision>();
						right = scene.transform.Find( "assert_collision_right" )
							.GetComponent<tests_tool.Assert_colision>();
						floor = scene.transform.Find( "floor_1" )
							.GetComponent<tests_tool.Assert_colision>();
						motor = player.GetComponent<NPC_danmaku_isometric_motor_3d>();
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
						helper.game_object.clean.scene();
					}

					[UnityTest]
					public IEnumerator
						when_attack_should_no_be_affected_by_his_own_bullets()
					{
						var hp = player.GetComponent<damage.motor.HP_motor>();
						yield return new WaitForSeconds( 1f );
						float old_hp = hp.current_points;
						motor.attack();
						yield return new WaitForSeconds( 1f );
						float new_hp = hp.current_points;
						Assert.AreEqual( old_hp, new_hp );
					}

					[UnityTest]
					public IEnumerator the_bullet_should_go_outside_of_player()
					{
						yield return new WaitForSeconds( 1f );
						var gun = helper.game_object.Find._<weapon.gun.Gun_base>(
							player, "linear_gun_simple" );
						var bullet = gun.shot( motor.my_rol );
						yield return new WaitForSeconds( 1f );
						Assert.IsFalse( helper.game_object.comp.is_null( bullet ) );
					}

					[UnityTest]
					public IEnumerator the_damage_in_the_bullet_should_be_motor()
					{
						yield return new WaitForSeconds( 1f );
						var gun = helper.game_object.Find._<weapon.gun.Gun_base>(
							player, "linear_gun_simple" );
						var bullet = gun.shot( motor.my_rol );
						Assert.Greater( bullet.damages.Length, 0 );
						Assert.IsNotNull( motor.my_rol );
						foreach ( damage.Damage damage in bullet.damages )
							Assert.AreEqual( damage.owner, motor.my_rol );
					}
				}
			}
		}
	}
}
