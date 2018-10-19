using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace controller
{
	namespace motor
	{
		namespace tree_d
		{
			namespace platform_bender
			{
			public class Test_summon
			{
					GameObject player, scene;
					tests_tool.Assert_colision left, right;

					[SetUp]
					public void Instanciate_scenary()
					{
						scene =
							Resources.Load(
								"_test/scene/controller/3d/" +
								"platform/basic_platform_bender" ) as GameObject;
						scene = helper.instantiate._( scene );
						player = scene.transform.Find( "player" ).gameObject;
					}

					[TearDown]
					public void clean_scenary()
					{
						MonoBehaviour.DestroyImmediate( scene );
					}

					[UnityTest]
					public IEnumerator platform_are_copies()
					{
						var controller = player.GetComponent<
							controllers.NPC_platform_bending_controller>();
						yield return new WaitForSeconds( 0.1f );
						var p1 = controller.summon_left_platform();
						var p2 = controller.summon_right_platform();
						Assert.IsTrue(
							p1.name.Contains( "Clone" ),
							string.Format(
								"la nueva plataforma creada no es un clone, {0}",
								p1.name )
							);
						Assert.IsTrue(
							p2.name.Contains( "Clone" ),
							string.Format(
								"la nueva plataforma creada no es un clone, {0}",
								p2.name )
							);
						MonoBehaviour.DestroyImmediate( p1 );
						MonoBehaviour.DestroyImmediate( p2 );
					}

					[UnityTest]
					public IEnumerator platform_should_be_in_the_same_rotation()
					{
						var controller = player.GetComponent<
							controllers.NPC_platform_bending_controller>();
						yield return new WaitForSeconds( 0.1f );
						var p1 = controller.summon_left_platform();
						var p2 = controller.summon_right_platform();
						Assert.AreEqual(
							p1.transform.rotation,
							controller.platform_left.transform.rotation );
						Assert.AreEqual(
							p2.transform.rotation,
							controller.platform_right.transform.rotation );
						MonoBehaviour.DestroyImmediate( p1 );
						MonoBehaviour.DestroyImmediate( p2 );
					}
				}
			}
		}
	}
}
