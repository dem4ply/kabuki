using UnityEngine;
using System.Collections;
using route;

public class Ai_steering_behavior : chibi_base.Chibi_behaviour
{
	public controller.controllers.Controller_2d controller;

	public Vector3 current_position
	{
		get { return controller.transform.position; }
	}

	/// <summary>
	/// genera un vector de direcion que intenta de seguir al target
	/// </summary>
	/// <param name="target">gameobject a seguir</param>
	/// <returns>direcion para seguir al target</returns>
	public Vector3 seek( GameObject target )
	{
		return seek( target.transform.position );
	}

	/// <summary>
	/// genera un vector de direcion que intenta de seguir al target
	/// </summary>
	/// <param name="target">vector3 a seguir</param>
	/// <returns>direcion para seguir al target</returns>
	public Vector3 seek( Vector3 target )
	{
		return target - controller.transform.position;
	}

	/// <summary>
	/// genera el vector para huir del target
	/// </summary>
	/// <param name="target">gameobject del que se quiere huir</param>
	/// <returns>direcion para huir del target</returns>
	public Vector3 flee( GameObject target )
	{
		return flee( target.transform.position );
	}

	/// <summary>
	/// genera el vector para huir del target
	/// </summary>
	/// <param name="target">posicion del que se quiere huir</param>
	/// <returns>direcion para huir del target</returns>
	public Vector3 flee( Vector3 target )
	{
		return controller.transform.position - target;
	}

	protected Segment get_segmen_to_use( Route route )
	{
		Segment segment = route.find_nearest_segment( current_position );

		Vector3 direction_to_end = segment.direction_to_end( current_position );
		float distance_to_end = direction_to_end.magnitude;
		if ( distance_to_end < segment.radius )
			segment = route.give_the_next_segment( segment );
		return segment;
	}

	public Vector3 follow_path( GameObject target )
	{
		Route route = target.GetComponent<Route>();
		if ( route == null )
		{
			Debug.LogWarning( "el objetivo no tiene Route" );
			return seek( target );
		}
		return follow_path( route );
	}

	public Vector3 follow_path( Route route )
	{
		Segment segment = get_segmen_to_use( route );

		Vector3 velocity_vector = controller.velocity_vector;
		debug.draw.arrow( velocity_vector );

		Vector3 prediction_position = velocity_vector + current_position;

		prediction_position = current_position + prediction_position.normalized;
		debug.draw.arrow_to( prediction_position );
		Vector3 projection_point = segment.project( prediction_position );

		debug.draw.line( prediction_position, projection_point );

		float distance = Vector3.Distance( prediction_position, projection_point );
		if ( distance > segment.radius )
		{
			Vector3 direction_to_move = segment.end.position - projection_point;
			direction_to_move = direction_to_move.normalized * segment.radius;
			Vector3 position_to_move = direction_to_move + projection_point;
			return position_to_move;
		}
		return Vector3.zero;
	}

	/// <summary>
	/// asigna la direcion del control como seek
	/// </summary>
	/// <param name="target">objetivo al que se quiiere seguir</param>
	public void do_seek( GameObject target )
	{
		controller.direction_vector = seek( target );
	}

	/// <summary>
	/// asigna la direcion del control como flee
	/// </summary>
	/// <param name="target">objetivo del que se quiere huir</param>
	public void do_flee( GameObject target )
	{
		controller.direction_vector = flee( target );
	}

	public void do_follow_path( GameObject target )
	{
		controller.direction_vector = follow_path( target );
	}
}
