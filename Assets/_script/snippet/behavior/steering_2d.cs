using UnityEngine;
using System.Collections;

namespace behavior
{
	namespace two_d
	{
		public static class steering
		{
			/// <summary>
			/// genera un vector de direcion que intenta de seguir al target
			/// </summary>
			/// <param name="target">gameobject a seguir</param>
			/// <returns>direcion para seguir al target</returns>
			public static Vector3 seek( GameObject target, GameObject controller )
			{
				return seek( target.transform, controller.transform );
			}

			public static Vector3 seek( Transform target, Transform controller )
			{
				return seek( target.position, controller.position );
			}

			public static Vector3 seek( Vector3 target, Vector3 controller )
			{
				return target - controller;
			}

			/// <summary>
			/// genera el vector para huir del target
			/// </summary>
			/// <param name="target">gameobject del que se quiere huir</param>
			/// <returns>direcion para huir del target</returns>
			public static Vector3 flee( GameObject target, GameObject controller )
			{
				return flee( target.transform, controller.transform );
			}

			public static Vector3 flee( Transform target, Transform controller )
			{
				return flee( target.position, controller.position );
			}

			public static Vector3 flee( Vector3 target, Vector3 controller )
			{
				return controller - target;
			}

			/// <summary>
			/// persige al objecto predicion hacia donde estara
			/// </summary>
			/// <param name="target"></param>
			/// <param name="controller"></param>
			/// <param name="max_speed"></param>
			/// <returns></returns>
			public static Vector3 pursuit(
				GameObject target, GameObject controller, float max_speed )
			{
				Rigidbody2D rid_2d = target.GetComponent<Rigidbody2D>();
				if ( rid_2d != null )
					return pursuit(
						target.transform.position, rid_2d.velocity,
						controller.transform.position, max_speed );
				return seek( target, controller );
			}

			public static Vector3 pursuit(
				Vector3 target, Vector3 velocity, Vector3 current_position,
				float max_speed )
			{
				float distance_to_target = Vector3.Distance(
					target, current_position );
				float time_to_reach_target = distance_to_target / max_speed;
				Vector3 predicted_speed = velocity.normalized * time_to_reach_target;
				Vector3 predicted_position = target + predicted_speed;
				return seek( predicted_position, current_position );
			}

			/// <summary>
			/// huye al objecto predicion hacia donde estara
			/// </summary>
			/// <param name="target"></param>
			/// <param name="controller"></param>
			/// <param name="max_speed"></param>
			/// <returns></returns>
			public static Vector3 evade(
				GameObject target, GameObject controller, float max_speed )
			{
				Rigidbody2D rid_2d = target.GetComponent<Rigidbody2D>();
				if ( rid_2d != null )
					return evade(
						target.transform.position, rid_2d.velocity,
						controller.transform.position, max_speed );
				return flee( target, controller );
			}

			public static Vector3 evade(
				Vector3 target, Vector3 velocity, Vector3 current_position,
				float max_speed )
			{
				float distance_to_target = Vector3.Distance( target, current_position );
				float time_to_reach_target = distance_to_target / max_speed;
				Vector3 predicted_speed = velocity.normalized * time_to_reach_target;
				Vector3 predicted_position = target - predicted_speed;
				return flee( predicted_position, current_position );
			}
		}
	}
}