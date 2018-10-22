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
				public class AI_controller_3d : Controller_3d
				{
					state.State current_state;

					protected virtual void Update()
					{
						current_state.update( this );
					}
				}
			}
		}
	}
}
