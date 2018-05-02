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

				public void line( Vector3 position, Vector3 to_position )
				{
					if ( debuging )
						UnityEngine.Debug.DrawLine( position, to_position );
				}

				public void arrow(
					Vector3 position, Vector3 direction, Color color )
				{
					if ( debuging )
						helper.draw.arrow.debug( position, direction, color );
				}

				public void line(
					Vector3 position, Vector3 to_position, Color color )
				{
					if ( debuging )
						UnityEngine.Debug.DrawLine( position, to_position, color );
				}

				public void arrow( Vector3 direction, Color color )
				{
					arrow( _instance.transform.position, direction, color );
				}

				public void line( Vector3 to_position, Color color )
				{
					line( _instance.transform.position, to_position, color );
				}

				public void line( Vector3 to_position )
				{
					line( _instance.transform.position, to_position );
				}

				public void arrow( Vector3 direction )
				{
					arrow( _instance.transform.position, direction );
				}

				public void arrow_to( Vector3 position, Vector3 to_position )
				{
					arrow( position, to_position - position );
				}

				public void arrow_to(
					Vector3 position, Vector3 to_position, Color color )
				{
					arrow( position, to_position - position, color );
				}

				public void arrow_to( Vector3 to_position )
				{
					Vector3 direction = to_position - _instance.transform.position;
					arrow( _instance.transform.position, direction );
				}

				public void arrow_to( Vector3 to_position, Color color )
				{
					Vector3 direction = to_position - _instance.transform.position;
					arrow( _instance.transform.position, direction, color );
				}
			}
		}
	}
}
