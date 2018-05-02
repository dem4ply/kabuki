using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_flee : Ai_walk
		{
			public GameObject target;

			/// <summary>
			/// genera un vector en la direcion que quiere escapar
			/// </summary>
			/// <param name="target">objetivo del que quiere huir</param>
			/// <returns>direcion a la que se quiere escapar</returns>
			public Vector3 flee( GameObject target )
			{
				return flee( target.transform.position );
			}

			/// <summary>
			/// genera un vector que indica la direcion en la que el
			/// la ia quiere huir
			/// </summary>
			/// <param name="target">posicion del objetivo del que
			/// se desea huir</param>
			/// <returns>direcion en la que se quiere huir</returns>
			public Vector3 flee( Vector3 target )
			{
				Vector3 desire_direction = controller.transform.position - target;
				return desire_direction;
			}

			protected override void Update()
			{
				controller.direction_vector = flee( target ).normalized;
			}
		}
	}
}