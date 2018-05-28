using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using radar;

namespace test_radar
{
	namespace radar_2d
	{
		namespace radar_2d_box
		{
			public class Test_radar_box_contruct
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
					obj.AddComponent<BoxCollider2D>();
					objects.Add( obj );
					return obj.transform;
				}

				[UnityTest]
				public IEnumerator in_the_start_the_masks_hits_shouls_be_empty()
				{
					yield return null;
					Transform obj = new_gameobject();
					yield return null;
					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.zero, 0f, 0f, masks );

					Assert.IsNotNull( radar.masks_hits );
					Assert.IsEmpty(
						radar.masks_hits,
						"el dicionario de los hits deberia de estar vacio" );
				}

				[UnityTest]
				public IEnumerator should_ignore_the_transform_of_have_assingned()
				{
					yield return null;
					Transform obj = new_gameobject();
					yield return null;
					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.zero, 0f, 0f, masks );

					radar.ping();
					Assert.IsEmpty(
						radar.masks_hits,
						"el radar no esta ignorando al mismo " +
						"transform que tiene asignado en el dicionario de hits" );

					Assert.IsEmpty(
						radar.hits,
						"el radar no esta ignorando al mismo" +
						"transform que tiene asignado en la lista de hits" );
				}

				[UnityTest]
				public IEnumerator the_list_of_hits_should_be_empty()
				{
					yield return null;
					Transform obj = new_gameobject();
					yield return null;
					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.zero, 0f, 0f, masks );

					radar.ping();
					Assert.IsEmpty(
						radar.hits,
						"el radar deberia de iniciar con lista vacia de hits" );
				}

				[UnityTest]
				public IEnumerator should_find_another_gameobjects_with_collider()
				{
					yield return null;
					Transform obj = new_gameobject();
					Transform other_object = new_gameobject();
					other_object.name = "otro";
					yield return null;
					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.zero, 0f, 0f, masks );

					radar.ping();
					Assert.IsNotEmpty(
						radar.hits,
						"el radar deberia de tener algun hit" );
					Assert.IsNotEmpty(
						radar.masks_hits[ mask ],
						"el dicionario de de mascaras y hits no deberia de estar vacio"
					);

					Assert.AreEqual( "otro", radar.hits[ 0 ].transform.name );
					Assert.AreEqual( other_object, radar.hits[ 0 ].transform );
				}

				[UnityTest]
				public IEnumerator should_only_find_elements_are_in_the_collider()
				{
					yield return null;
					Transform obj = new_gameobject();
					Transform other_object = new_gameobject();
					Transform should_no_finded = new_gameobject();
					other_object.name = "otro";
					should_no_finded.name = "no_finded";
					other_object.transform.position = new Vector3( 1, 0 );
					should_no_finded.transform.position = new Vector3( 4, 0 );
					yield return null;

					List<LayerMask> masks = new List<LayerMask>();
					LayerMask mask = new LayerMask();
					mask.value = ~0;
					masks.Add( mask );

					Radar_box radar = new Radar_box(
						obj.transform, new Vector3( 1f, 1f, 1f ),
						Vector3.zero, 0f, 0f, masks );

					radar.ping();

					Assert.AreEqual( other_object, radar.hits[ 0 ].transform );
					foreach ( Radar_hit radar_hit in radar.hits )
						if ( radar_hit.transform == should_no_finded )
							Assert.Fail(
								"el objeto que esta a distacion no debeio " +
								"de haber sido encontrado" );
				}
			}
		}
	}
}