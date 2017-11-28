using UnityEngine;
using System.Collections;
using controller.animator;
using controller.motor;
using controller.controllers;
using chibi_base;

namespace controller {
	namespace joystick {
		public class Joystick : Chibi_behaviour {

			#region public vars
			public string key_map = "player 1";
			public controller.controllers.NPC_controller controller;

			public Vector2 axis_mouse = Vector2.zero;
			public Vector2 axis_esdf = Vector2.zero;
			public Vector2 mouse_position = Vector2.zero;
			public float mouse_wheel = 0f;

			public bool run_key = false;

			public float dead_zone_esdf_axis = 0.01f;
			public float dead_zone_mouse_axis = 0.01f;
			public float dead_zone_mouse_wheel = 0.01f;
			#endregion

			#region public properties
			public bool is_pass_deadzone_esdf_axis {
				get;
				protected set;
			}
			public bool is_pass_deadzone_mouse_axis {
				get;
				protected set;
			}
			public bool is_pass_deadzone_mouse_wheel {
				get;
				protected set;
			}
			#endregion

			#region public functions
			public void update_all_axis() {
				_get_axis_esdf();
				_get_axis_mouse();
				_get_mouse_pos();
			}

			public void update_all_buttons() {
				_get_keys_running();
			}
			#endregion

			#region funciones protegdas
			protected void Update() {
				update_all_axis();
				update_all_buttons();
				// si pasa la zona muerta el stick entonces se mueve y cambia la direcion
				if ( is_pass_deadzone_esdf_axis ) {
					controller.direction_vector = axis_esdf;
				}
				else
					controller.direction_vector = Vector2.zero;
				controller.is_running = run_key;
				_draw_debug();
			}

			/// <summary>
			/// actualiza el eje de movimiento
			/// </summary>
			protected void _get_axis_esdf() {
				axis_esdf = helper.joystick.axis_left;
				is_pass_deadzone_esdf_axis = helper.joystick.pass_dead_zone( axis_esdf.magnitude, dead_zone_esdf_axis );
			}

			/// <summary>
			/// revisa si se preciono el boton para correr
			/// </summary>
			protected void _get_keys_running() {
				run_key = Input.GetButton( "run" );
			}

			/// <summary>
			/// actualiza el eje de movimiento del mouse
			/// </summary>
			protected void _get_axis_mouse() {
				axis_mouse.x = helper.mouse.axis_x;
				axis_mouse.y = helper.mouse.axis_y;
				mouse_wheel = helper.mouse.wheel;
				is_pass_deadzone_mouse_axis = helper.joystick.pass_dead_zone( axis_mouse.magnitude, dead_zone_mouse_axis );
				is_pass_deadzone_mouse_wheel = helper.joystick.pass_dead_zone( mouse_wheel, dead_zone_mouse_wheel );
			}

			/// <summary>
			/// actualiza la posicion del mouse
			/// </summary>
			protected void _get_mouse_pos() {
				mouse_position = Input.mousePosition;
			}

			/// <summary>
			/// inicializa el chache del script
			/// </summary>
			protected override void _init_cache() {
				_init_cache_controller();
			}

			/// <summary>
			/// inicia el cache del controller
			/// </summary>
			protected virtual void _init_cache_controller() {
				if ( controller == null )
					controller = GetComponent<NPC_controller>();
			}

			/// <summary>
			/// dibuga el debug
			/// </summary>
			protected virtual void _draw_debug() {
				Debug.DrawRay( transform.position, axis_esdf * 3, Color.magenta, 0, true );
			}
			#endregion
		}
	}
}