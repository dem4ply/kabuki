using UnityEngine;
using System.Collections.Generic;


namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace stats
				{
					[CreateAssetMenu( menuName = "controller/ai/stat/Orbit" )]
					public class Orbit : Stat
					{
						public float x_radius = 1;
						public float z_radius = 1;
						public float speed = 1;
					}
				}
			}
		}
	}
}
