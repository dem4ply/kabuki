using UnityEngine;
using behavior.tree_d;

namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace behavior
				{
					[CreateAssetMenu( menuName = "controller/3d/ai/behavior/orbit" )]
					public class Orbit : Behavior
					{
						public override Vector3 act( AI_controller_3d controller )
						{
							stats.Orbit stat = controller.stat as stats.Orbit;
							if ( stat == null )
							{
								Debug.LogError( string.Format(
									"Los stat de {0} no son del tipo orbit",
									controller.name ) );
								return Vector3.zero;
							}
							Vector3 target_position =
								controller.target.transform.position;
							float x = stat.x_radius
								* Mathf.Cos( Time.time * stat.speed )
								+ target_position.x;
							float z = stat.z_radius
								* Mathf.Sin( Time.time * stat.speed )
								+ target_position.z;

							Vector3 result = new Vector3( x, target_position.y, z );
							controller.controller.desire_direction =
								steering.seek(
									result, controller.controller.transform.position );
							return result;
						}
					}
				}
			}
		}
	}
}
