using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using radar;

namespace events
{
	namespace scene
	{
		namespace handler
		{
			public class Test_event_handler
			{
				GameObject handler, scene;
				Event_scene event_scene;

				[SetUp]
				public void Instanciate_scenary()
				{
					scene =
						Resources.Load(
							"_test/scene/event/test_event_scene" ) as GameObject;
					scene = helper.instantiate._( scene );
					handler = scene.transform.Find( "event_handle" ).gameObject;
					event_scene = scene.transform.Find( "encounter" )
						.GetComponent<Event_scene>();
				}

				[TearDown]
				public void clean_scenary()
				{
					MonoBehaviour.DestroyImmediate( scene );
				}

				[UnityTest]
				public IEnumerator when_event_reach_handler_should_opened()
				{
					yield return new WaitForSeconds( 2f );
					GameObject route = GameObject.Find( string.Format(
						"{0}(Clone)", event_scene.prefab_event_scene.name ) );
					Assert.IsFalse( helper.game_object.comp.is_null( route ) );
				}
			}
		}
	}
}