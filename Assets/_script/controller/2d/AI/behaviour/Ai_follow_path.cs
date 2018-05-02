using UnityEngine;
using route;

namespace controller
{
	namespace ai
	{
		public class Ai_follow_path : Ai_seek
		{
			public Segment current_segment;

			/// <summary>
			/// extrar el componente de Route y sigue el camino
			/// si no tiene el target un Route component usara seek en el target
			/// </summary>
			/// <param name="target">objetivo con un componente Route a seguir</param>
			protected void follow( GameObject target )
			{
				helper.draw.arrow.debug( transform.position, desire_direction );
				Route route = target.GetComponent<Route>();
				if ( route == null )
				{
					Debug.LogWarning( "no tiene routa el target" );
					seek( target );
				}

				Segment segment = route.find_nearest_segment(
					transform.position );
				Debug.Log( segment.index );
				float disntan_of_end_position = ( segment.end.position - transform.position ).magnitude;
				if ( disntan_of_end_position < segment.radius )
					segment = route.give_the_next_segment( segment );

				Vector3 prediction_position = ( Vector3 )controller.velocity_vector + transform.position;
				prediction_position = transform.position + prediction_position.normalized;
				Vector3 projection_point = segment.project( prediction_position );

				float distance = Vector3.Distance( prediction_position, projection_point );
				if ( distance > segment.radius )
				{
					Vector3 direction_to_move = segment.end.position - projection_point;
					direction_to_move = direction_to_move.normalized * segment.radius;
					helper.draw.arrow.debug( projection_point, direction_to_move, Color.black );
					Vector3 position_to_move = direction_to_move + projection_point;
					helper.draw.arrow.debug( transform.position,  position_to_move - transform.position, Color.blue );
					seek( direction_to_move + projection_point );
				}
			}

			protected override void Update()
			{
				follow( target );
				controller.direction_vector = desire_direction;
			}

			protected override void OnDrawGizmos()
			{
			}
		}
	}
}
