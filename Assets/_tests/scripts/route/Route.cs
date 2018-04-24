using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.motor;

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
		route.Route route  = road.GetComponent<route.Route>();
		GameObject point = route.find_near_point( point_1.transform.position );
		Assert.AreEqual( point.name, "GameObject" );
		point = route.find_near_point( point_2.transform.position );
		Assert.AreEqual( point.name, "GameObject" );
		point = route.find_near_point( point_3.transform.position );
		Assert.AreEqual( point.name, "GameObject (1)" );
		point = route.find_near_point( point_4.transform.position );
		Assert.AreEqual( point.name, "GameObject (1)" );
		point = route.find_near_point( point_5.transform.position );
		Assert.AreEqual( point.name, "GameObject (2)" );
		yield return null;
	}

}
