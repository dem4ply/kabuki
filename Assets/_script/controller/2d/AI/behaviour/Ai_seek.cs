using UnityEngine;

namespace controller
{
	namespace ai
	{
		public class Ai_seek : Ai_walk
		{
			public GameObject target;

			/// <summary>
			/// modifica el desire_direction para seguir al target
			/// </summary>
			/// <param name="target">objetivo a seguir</param>
			public void seek( GameObject target )
			{
				desire_direction = target.transform.position
					- controller.transform.position;
				desire_direction.Normalize();
			}


			/// <summary>
			/// modifica el desire_direction para seguir al target
			/// </summary>
			/// <param name="target">vector que representa cordenadas</param>
			public void seek( Vector3 target )
			{
				desire_direction = target - controller.transform.position;
				desire_direction.Normalize();
			}

			protected override void Update()
			{
				seek( target );
				base.Update();
			}
		}
	}
}