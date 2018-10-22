using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using System;

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
					public state.State current_state;
					public GameObject target;

					protected override void Update()
					{
						current_state.update( controller );
					}
				}
			}
		}
	}
}
