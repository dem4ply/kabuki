using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;


namespace tests_tool
{
	public class Assert_colision : chibi_base.Chibi_behaviour
	{
		List<obj.Assert_collision_event> collisions_enters;
		List<obj.Assert_collision_event> collisions_exits;

		protected override void Awake()
		{
			base.Awake();
			collisions_enters = new List<obj.Assert_collision_event>();
			collisions_exits = new List<obj.Assert_collision_event>();
		}

		public void assert_collision_enter()
		{
			if ( collisions_enters.Count == 0 )
				Assert.Fail( "ningun collider entro" );
		}

		public void assert_collision_enter( GameObject obj )
		{
			foreach ( var e in this.collisions_enters )
				if ( e.game_object == obj )
					return;
			string msg = string.Format(
				"el gameobject {0} no entro en el collider {1}", obj, name );
			Assert.Fail( msg );
		}

		public void assert_collision_enter( MonoBehaviour obj )
		{
			assert_collision_enter( obj.gameObject );
		}

		public void assert_collision_enter( int amount )
		{
			if ( collisions_enters.Count != amount )
				Assert.Fail( string.Format(
					"el numero de collisiones fueron {0} se esperaban {1} en {2}",
					collisions_enters.Count, amount, name ) );
		}

		public void assert_collision_enter_less_that( int amount )
		{
			if ( collisions_enters.Count >= amount )
				Assert.Fail( string.Format(
					"el numero de collisiones fueron {0} se esperaban menos de {1}" +
					" en {2}",
					collisions_enters.Count, amount, name ) );
		}

		public void assert_collision_enter_less_or_equal_that( int amount )
		{
			if ( collisions_enters.Count >= amount )
				Assert.Fail( string.Format(
					"el numero de collisiones fueron {0} se esperaban menos de {1}" +
					" en {2}",
					collisions_enters.Count, amount, name ) );
		}

		public void assert_not_collision_enter()
		{
			if ( collisions_enters.Count > 0 )
				Assert.Fail( "se encontraron collisiones" );
		}

		public void assert_not_collision_enter( GameObject obj )
		{
			foreach ( var e in collisions_enters )
				if ( e.game_object == obj )
				{
					string msg = string.Format(
						"el gameobject {0} entro en el collider", obj );
					Assert.Fail( msg );
				}
		}

		public void assert_not_collision_exit( GameObject obj )
		{
			foreach ( var e in collisions_exits )
				if ( e.game_object == obj )
				{
					string msg = string.Format(
						"el gameobject {0} nunca salio del collider", obj );
					Assert.Fail( msg );
				}
		}


		public void assert_not_collision_enter( MonoBehaviour obj )
		{
			assert_not_collision_enter( obj.gameObject );
		}

		private void OnCollisionEnter( Collision collision )
		{
			collisions_enters.Add( new obj.Assert_collision_event( collision ) );
		}

		private void OnTriggerEnter( Collider other )
		{
			collisions_enters.Add( new obj.Assert_collision_event( other ) );
		}

		private void OnCollisionExit( Collision collision )
		{
			collisions_exits.Add( new obj.Assert_collision_event( collision ) );
		}

		private void OnTriggerExit( Collider other )
		{
			collisions_exits.Add( new obj.Assert_collision_event( other ) );
		}
	}
}
