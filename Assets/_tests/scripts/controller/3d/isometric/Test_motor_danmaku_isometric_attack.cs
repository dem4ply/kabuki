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
					: helper.tests.Scene_test
				{
					GameObject player;
					NPC_danmaku_isometric_motor_3d motor;

					public override void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"isometric/basic_move_danmaku" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
						motor = player.GetComponent<NPC_danmaku_isometric_motor_3d>();
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
