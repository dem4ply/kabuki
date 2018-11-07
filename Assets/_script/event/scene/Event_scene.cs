using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace events
{
	namespace scene
	{
		public class Event_scene : chibi_base.Chibi_behaviour
		{
			public GameObject prefab_event_scene;

			public virtual GameObject open()
			{
				GameObject obj = helper.instantiate._( prefab_event_scene );
				return obj;
			}
		}
	}
}