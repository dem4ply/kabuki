using UnityEngine;
using System.Collections;
using chibi_base;

namespace helper
{
	namespace debug
	{
		namespace draw
		{
			public class Draw
			{
				protected Chibi_behaviour _instance;

				public bool debuging
				{
					get { return _instance.debug_mode;  }
				}

				public Draw( Chibi_behaviour instance )
				{
					_instance = instance;
				}

				public void arrow( Vector3 position, Vector3 direction )
				{
					if ( debuging )
						helper.draw.arrow.debug( position, direction );
				}

				public void arrow(
					Vector3 position, Vector3 direction, Color color )
				{
					if ( debuging )
						helper.draw.arrow.debug( position, direction, color );
				}

				public void arrow( Vector3 direction, Color color )
				{
					arrow( _instance.transform.position, direction, color );
				}

				public void arrow( Vector3 direction )
				{
					arrow( _instance.transform.position, direction );
				}
			}
		}
	}
}
