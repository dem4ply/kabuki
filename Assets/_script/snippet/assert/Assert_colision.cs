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
			string msg = string.Format( "el gameobject {0} no entro en el collider", obj );
			Assert.Fail( msg );
		}

		public void assert_not_collision_enter()
		{
			if ( collisions_enters.Count > 0 )
				Assert.Fail( "se encontraron collisiones" );
		}

		public void assert_not_collision_enter( GameObject obj )
		{
			foreach ( var e in this.collisions_enters )
				if ( e.game_object == obj )
				{
					string msg = string.Format(
						"el gameobject {0} entro en el collider", obj );
					Assert.Fail( msg );
				}
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
