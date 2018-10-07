using UnityEngine;

namespace helper
{
	namespace game_object
	{
		public class Find
		{
			/// <summary>
			/// busca los hijos del gameobject de manera recursiva
			/// </summary>
			/// <param name="obj">padre en el qeu se buscaran</param>
			/// <param name="name">nombre del object qe se busca</param>
			/// <returns>hijo encontrado</returns>
			public static GameObject _( GameObject obj, string name )
			{
				Transform result = _( obj.transform, name );
				if ( result != null )
					return result.gameObject;
				return null;
			}

			public static Transform _( Transform obj, string name )
			{
				Transform result = obj.Find( name );
				if ( result != null )
					return result;
				for ( int i = 0; i < obj.childCount; ++i )
				{
					result = _( obj.GetChild( i ), name );
					if ( result != null )
						return result;
				}
				return null;
			}
		}
	}
}