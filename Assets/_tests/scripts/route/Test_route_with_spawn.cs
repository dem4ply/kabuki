using NUnit.Framework;
using manager;

namespace route
{
	class Test_route_with_spawn
	{
		[Test]
		public void the_first_point_should_containt_the_spawn()
		{
			var s = new UnityEngine.GameObject();
			s.AddComponent<Route_with_spawn>();
			Route_with_spawn route = s.GetComponent<Route_with_spawn>();
			route.points = new System.Collections.Generic.List<UnityEngine.Transform>();
			route.clean_points();
			route.proto_point = new UnityEngine.GameObject();
			var p = new UnityEngine.GameObject();
			p.AddComponent<spawner.Spawn_point>();
			route.proto_spawn_point = p.GetComponent<spawner.Spawn_point>();

			var generator = route.get_points().GetEnumerator();
			generator.MoveNext();
			var spawn = generator.Current.GetComponent<spawner.Spawn_point>();
			Assert.IsNotNull( spawn );
		}

		[Test]
		public void the_first_point_should_no_have_problems_when_no_have_target()
		{
			var s = new UnityEngine.GameObject();
			s.AddComponent<Route_with_spawn>();
			Route_with_spawn route = s.GetComponent<Route_with_spawn>();
			route.points = new System.Collections.Generic.List<UnityEngine.Transform>();
			route.clean_points();
			route.proto_point = new UnityEngine.GameObject();
			var p = new UnityEngine.GameObject();
			p.AddComponent<spawner.Spawn_point>();
			route.proto_spawn_point = p.GetComponent<spawner.Spawn_point>();

			var generator = route.get_points().GetEnumerator();
			generator.MoveNext();
			var spawn = generator.Current.GetComponent<spawner.Spawn_point>();
			Assert.IsNotNull( spawn );
		}

		[Test]
		public void the_spawn_should_have_assigned_the_target()
		{
			var s = new UnityEngine.GameObject();
			s.AddComponent<Route_with_spawn>();
			Route_with_spawn route = s.GetComponent<Route_with_spawn>();
			route.points = new System.Collections.Generic.List<UnityEngine.Transform>();
			route.clean_points();
			route.proto_point = new UnityEngine.GameObject();
			var p = new UnityEngine.GameObject();
			p.AddComponent<spawner.Spawn_to_route>();
			route.proto_spawn_point = p.GetComponent<spawner.Spawn_to_route>();

			var generator = route.get_points().GetEnumerator();
			generator.MoveNext();
			var spawn = generator.Current.GetComponent<spawner.Spawn_to_route>();
			Assert.IsNotNull( spawn );
			Assert.AreEqual( route.gameObject, spawn.target.gameObject );
		}
	}
}
