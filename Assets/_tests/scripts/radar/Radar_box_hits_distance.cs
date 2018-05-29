using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using radar;

namespace radar
{
	namespace radar_2d
	{
		namespace radar_2d_box
		{
			public class Test_radar_box_hits_distance
			{
				List<GameObject> objects;

				[SetUp]
				public void prepare_list_of_objects()
				{
					objects = new List<GameObject>();
				}

				[TearDown]
				public void clean_scenary()
				{
					foreach ( GameObject obj in objects )
						MonoBehaviour.DestroyImmediate( obj );
				}

				public Transform new_gameobject()
				{
					GameObject obj = new GameObject();
					obj.AddComponent< BoxCollider2D >();
					objects.Add( obj );
					return obj.transform;
				}

				[UnityTest]
				public IEnumerator should_no_find_no_one()
				{
					yield return null;
					Transform obj = new_gameobject();
					Transform no_finded_one = new_gameobject();
					Transform no_finded_two = new_gameobject();
					no_finded_one.name = "no_finded_one";
					no_finded_two.name = "no_finded_two";
					no_finded_one.transform.position = new Vector3( 7, 0 );
					no_finded_two.transform.position = new Vector3( 10, 0 );
					yield return null;

					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.right, 4f, 0f, masks );

					radar.ping();

					Assert.AreEqual(
						0, radar.hits.Count,
						"el radar no debio de haber encontrado a ningun objeto" );
				}

				[UnityTest]
				public IEnumerator should_find_all_elements()
				{
					yield return null;
					Transform obj = new_gameobject();
					Transform finded_one = new_gameobject();
					Transform finded_two = new_gameobject();
					finded_one.name = "finded_one";
					finded_two.name = "finded_two";
					finded_one.transform.position = new Vector3( 3, 1 );
					finded_two.transform.position = new Vector3( 3, -1 );
					yield return null;

					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.right, 4f, 0f, masks );

					radar.ping();

					Assert.AreEqual(
						2, radar.hits.Count,
						"el radar debio de haber encontrado los 2 elementos" );

					bool find_element = false;
					foreach ( Radar_hit radar_hit in radar.hits )
						if ( radar_hit.transform == finded_one )
							find_element = true;

					if ( !find_element )
						Assert.Fail( "el primer elemento no fue encontrado" );

					find_element = false;
					foreach ( Radar_hit radar_hit in radar.hits )
						if ( radar_hit.transform == finded_two )
							find_element = true;

					if ( !find_element )
						Assert.Fail( "el segundo elemento no fue encontrado" );
				}

				[UnityTest]
				public IEnumerator right_element_should_be_find()
				{
					yield return null;
					Transform obj = new_gameobject();
					Transform other_object = new_gameobject();
					Transform should_no_finded = new_gameobject();
					other_object.name = "otro";
					should_no_finded.name = "no_finded";
					other_object.transform.position = new Vector3( 3, 0 );
					should_no_finded.transform.position = new Vector3( 10, 0 );
					yield return null;

					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.right, 4f, 0f, masks );

					radar.ping();

					Assert.AreEqual(
						other_object, radar.hits[0].transform,
						"se debio de haber encontrado el objeto que esta  colicionado" +
						" con el radar" );

					Assert.AreEqual(
						1, radar.hits.Count,
						"el radar debio de haber solo encontrado un elemento" );
				}
			}
		}
	}
}