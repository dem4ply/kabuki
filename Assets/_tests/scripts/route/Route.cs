using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

namespace route
{
	public class Test_Route
	{
		GameObject road, scene, point_1, point_2, point_3, point_4, point_5;

		[SetUp]
		public void Instanciate_scenary()
		{
			scene =
				Resources.Load( "_prefab/tests/basic_road_chamber" ) as GameObject;
			scene = helper.instantiate._( scene );
			road = scene.transform.Find( "road" ).gameObject;
			point_1 = scene.transform.Find( "point_1" ).gameObject;
			point_2 = scene.transform.Find( "point_2" ).gameObject;
			point_3 = scene.transform.Find( "point_3" ).gameObject;
			point_4 = scene.transform.Find( "point_4" ).gameObject;
			point_5 = scene.transform.Find( "point_5" ).gameObject;
		}

		[TearDown]
		public void clean_scenary()
		{
			MonoBehaviour.DestroyImmediate( scene );
		}

		[UnityTest]
		public IEnumerator find_the_neardest_point()
		{
			route.Route route = road.GetComponent<route.Route>();
			Transform point = route.find_near_point( point_1.transform.position );
			Assert.AreEqual( point.name, "p1" );
			point = route.find_near_point( point_2.transform.position );
			Assert.AreEqual( point.name, "p1" );
			point = route.find_near_point( point_3.transform.position );
			Assert.AreEqual( point.name, "p2" );
			point = route.find_near_point( point_4.transform.position );
			Assert.AreEqual( point.name, "p2" );
			point = route.find_near_point( point_5.transform.position );
			Assert.AreEqual( point.name, "p3" );
			yield return null;
		}

		[UnityTest]
		public IEnumerator find_nearest_segment()
		{
			route.Route route_component = road.GetComponent<route.Route>();
			route.Segment segment = route_component.find_nearest_segment(
				point_1.transform.position );
			Assert.AreEqual( segment.start.name, "p1" );
			segment = route_component.find_nearest_segment(
				point_2.transform.position );
			Assert.AreEqual( segment.start.name, "p1" );
			segment = route_component.find_nearest_segment(
				point_3.transform.position );
			Assert.AreEqual( segment.start.name, "p1" );
			segment = route_component.find_nearest_segment(
				point_4.transform.position );
			Assert.AreEqual( segment.start.name, "p2" );
			segment = route_component.find_nearest_segment(
				point_5.transform.position );
			Assert.AreEqual( segment.start.name, "p2" );
			yield return null;
		}
	}
}
