using UnityEngine;
using System.Collections.Generic;

namespace manager
{
	public class Collision {
		public Dictionary<GameObject, List<Collision_info>> collisions;
		public Dictionary<string, List<Collision_info>> collisions_by_name;

		public Collision()
		{
			collisions = new Dictionary<GameObject, List< Collision_info>>();
			collisions_by_name = new Dictionary<string, List< Collision_info>>();
		}

		public void add( Collision_info collision_info )
		{
			throw new NotImplementedException();
		}

		public void remove( GameObject obj )
		{
			throw new NotImplementedException();
		}

		public List<Collision_info> get( GameObject obj )
		{
			List<Collision_info> result;
			if ( collisions.TryGetValue( obj, out result ) )
				return result;
			else
				return null;
		}

		public List<Collision_info> get( string name )
		{
			List<Collision_info> result;
			if ( collisions_by_name.TryGetValue( name, out result ) )
				return result;
			else
				return null;
		}
	}
}
