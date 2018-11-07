using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace events
{
	namespace scene
	{
		namespace handler
		{
			public class Event_handler : chibi_base.Chibi_behaviour
			{
				protected virtual void OnTriggerEnter( Collider other )
				{
					Event_scene event_scene = other.GetComponent<Event_scene>();
					if ( event_scene == null )
						return;
					event_scene.open();
				}
			}

		}
	}
}