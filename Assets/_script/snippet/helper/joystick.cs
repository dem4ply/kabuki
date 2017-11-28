using UnityEngine;
using System.Collections;

namespace helper {
	public class joystick {

		/// <summary>
		/// Obtiene el valor del eje X del stick izquierdo
		/// </summary>
		public static float axis_left_x {
			get {
				return Input.GetAxis( "horizontal" );
			}
		}

		/// <summary>
		/// Obtiene el valor del eje Y del stick izquierdo
		/// </summary>
		public static float axis_left_y {
			get {
				return Input.GetAxis( "vertical" );
			}
		}

		/// <summary>
		/// Obtiene el vector del stick izquierdo
		/// </summary>
		public static Vector2 axis_left {
			get {
				return new Vector2( axis_left_x, axis_left_y );
			}
		}

		/// <summary>
		/// decide si el eje paso la zona muerta
		/// </summary>
		/// <param name="value">valor a evaluar si pasa la zona muerta</param>
		/// <param name="dead_zone">tamaño de la sona muerta</param>
		/// <returns>si paso la zona muerta</returns>
		public static bool pass_dead_zone( float value, float dead_zone ) {
			return value < -dead_zone || dead_zone < value;
		}
	}
}