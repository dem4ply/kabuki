﻿using UnityEngine;


namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace behavior
				{
					[CreateAssetMenu( menuName = "controller/ai/behavior/base" )]
					public abstract class Behavior : chibi_base.Chibi_object
					{
						public abstract void act( Controller_3d controller );
					}
				}
			}
		}
	}
}
