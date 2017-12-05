using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using controller.animator;
using controller.motor;
using controller.controllers;
using chibi_base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace controller
{
	namespace ai
	{
		public class Ai_walk : Ai
		{
			public Vector2 desire_direction = Vector2.left;

			protected virtual void Update()
			{
				controller.direction_vector = desire_direction;
			}

			protected void OnDrawGizmos()
			{
				helper.draw.arrow.gizmo(
					transform.position, desire_direction, Color.magenta );
			}
		}
	}
}
