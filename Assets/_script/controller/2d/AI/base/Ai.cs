using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using controller.animator;
using controller.motor;
using controller.controllers;
using chibi_base;

namespace controller {
	namespace ai{
		public class Ai: Chibi_behaviour {
			public NPC_side_scroll_controller_2d controller;

			protected override void _init_cache()
			{
				base._init_cache();
				if ( controller == null )
					controller =
						transform.GetComponent<NPC_side_scroll_controller_2d>();
			}
		}
	}
}
