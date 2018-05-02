using UnityEngine;
using System.Collections;
using chibi_base;

namespace helper
{
	namespace debug
	{
		public class Debug
		{
			protected Chibi_behaviour _instance;
			public draw.Draw draw;

			public bool debuging
			{
				get { return _instance.debug_mode;  }
			}

			public Debug( chibi_base.Chibi_behaviour instance )
			{
				_instance = instance;
				draw = new draw.Draw( _instance );
			}
		}
	}
}
