using UnityEngine;
using System.Collections;

namespace weapon
{
	namespace gun
	{
		public class Linear_gun : Gun_base
		{

			public Vector3 direction_shot
			{
				get { return transform.forward.normalized; }
			}

			public override GameObject shot()
			{
				throw new System.NotImplementedException();
			}


			protected void OnDrawGizmos()
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere( transform.position, 0.2f );
				Gizmos.color = Color.red;
				helper.draw.arrow.gizmo( transform.position, direction_shot );
			}

		}
	}
}