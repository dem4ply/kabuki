using UnityEngine;
using System.Collections.Generic;

namespace manager
{
	public class Collision {
		public Dictionary<
			GameObject, Dictionary<string, Collision_info>> collisions;
		public Dictionary<string, List<Collision_info>> collisions_by_name;

		public Collision()
		{
			collisions = new Dictionary<
				GameObject, Dictionary<string, Collision_info>>();
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

		public Dictionary<string, Collision_info> this[ GameObject obj ]
		{
			get{
				Dictionary<string, Collision_info> result;
				collisions.TryGetValue( obj, out result );
				return result;
			}
		}

		public bool this[ GameObject obj, string name ]
		{
			get{
				var inner_dict = this[ obj ];
				Collision_info result;
				if ( inner_dict != null )
					return inner_dict.TryGetValue( obj, out result );
				return false;
			}
		}

		public List<Collision_info>this[ string name ]
		{
			get{
				List<Collision_info> result;
				return collisions_by_name.TryGetValue( name, out result );
			}
		}
	}
}
