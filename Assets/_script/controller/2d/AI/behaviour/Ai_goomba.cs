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
		public class Ai_goomba : Ai_walk
		{
			void OnCollisionEnter2D( Collision2D collision )
			{
				if ( collision.gameObject.tag == helper.consts.tags.scenary )
				{
					foreach ( ContactPoint2D contact in collision.contacts )
					{
						if ( should_invert_desire_direction( contact ) )
						{
							invert_desire_direction();
							break;
						}
					}
				}
			}

			protected virtual bool should_invert_desire_direction(
				ContactPoint2D contact )
			{
				// si la colicion fue con algo de enfrente
				if ( contact.normal.x != 0 )
				{
					float angle = Vector2.Angle( desire_direction, contact.normal );
					return helper.math.between( angle, 160, 200 );
				}
				return false;
			}

			protected virtual void invert_desire_direction()
			{
				desire_direction = new Vector2(
					-desire_direction.x, desire_direction.y );
			}
		}
	}
}
