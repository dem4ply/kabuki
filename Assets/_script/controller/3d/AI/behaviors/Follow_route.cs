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
					[CreateAssetMenu( menuName="controller/3d/ai/behavior/follow_route" )]
					public class Follow_route : Behavior
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
							return Vector3.up;
						}

						public override void prepare( AI_controller_3d controller )
						{
							Vector3 current_position =
								controller.controller.transform.position;
							Vector3 direction =
								current_position
								- controller.target.transform.position;
							controller.properties.angle_x = helper.shapes.Ellipse
								.get_progrest( direction );

						}
					}
				}
			}
		}
	}
}
