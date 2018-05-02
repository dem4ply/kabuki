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

	/// <summary>
	/// suigue una el camino generado por un objeto tipo Route
	/// </summary>
	/// <param name="route"></param>
	/// <returns>direcion para moverse hacia la ruta si regresa
	/// Vector3.zero no es nesesario cambiar el vector de direcion</returns>
	public Vector3 follow_path( Route route )
	{
		Segment segment = get_segmen_to_use( route );

		Vector3 velocity_vector = controller.velocity_vector;
		Vector3 prediction_position = current_position + velocity_vector.normalized;

		debug.draw.arrow_to( prediction_position, Color.green );
		Vector3 projection_point = segment.project( prediction_position );

		debug.draw.line( prediction_position, projection_point, Color.blue );

		float distance = Vector3.Distance(
			prediction_position, projection_point );

		if ( distance > segment.radius )
		{
			Vector3 direction_to_move = segment.end.position - projection_point;
			direction_to_move = direction_to_move.normalized * segment.radius;
			Vector3 position_to_move = direction_to_move + projection_point;
			debug.draw.arrow_to( position_to_move, Color.black );
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
		Vector3 desire_direction = seek( target );
		debug.draw.arrow( desire_direction, Color.magenta );
		controller.direction_vector = desire_direction;
	}

	public void do_seek( Vector3 target )
	{
		Vector3 desire_direction = seek( target );
		debug.draw.arrow( desire_direction, Color.magenta );
		controller.direction_vector = desire_direction;
	}

	/// <summary>
	/// asigna la direcion del control como flee
	/// </summary>
	/// <param name="target">objetivo del que se quiere huir</param>
	public void do_flee( GameObject target )
	{
		Vector3 desire_direction = flee( target );
		debug.draw.arrow( desire_direction, Color.magenta );
		controller.direction_vector = desire_direction;
	}

	public void do_follow_path( GameObject target )
	{
		Vector3 desire_position = follow_path( target );
		if ( desire_position != Vector3.zero )
			do_seek( desire_position );
	}
}
