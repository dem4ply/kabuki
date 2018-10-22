using UnityEngine;
using System.Collections;


namespace weapon
{
	namespace stat
	{
		[ CreateAssetMenu( menuName="weapon/stat/base") ]
		public class Gun_stat : chibi_base.Chibi_object
		{
			public float rate_fire;

			public override string path_of_the_default
			{
				get { return "object/weapon/stat/default"; }
			}
		}
	}
}