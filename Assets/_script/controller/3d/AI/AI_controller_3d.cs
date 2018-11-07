﻿using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;
using controller.controllers.ai.tree_d.state;
using controller.controllers.ai.tree_d.stats;
using controller.controllers.ai.tree_d.behavior;
using behavior.tree_d;

namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				public class AI_controller_3d : AI_base_3d
				{
					public State state;
					public Stat stat;
					public Transform target;

					public data.Properties _properties;

					public data.Properties properties
					{
						get {
							if ( _properties == null )
								_properties = new data.Properties();
							return _properties;
						}
					}

					protected override void Update()
					{
						if ( target != null && state != null )
						{
							state.update( this );
						}
						else
							Debug.LogWarning(
								string.Format(
									"el {0} no tiene target o state", name ) );
					}

					protected virtual void prepare()
					{
						if ( state != null )
							state.prepare( this );
					}

					protected override void _init_cache()
					{
						base._init_cache();
						prepare();
					}
				}
			}
		}
	}
}
