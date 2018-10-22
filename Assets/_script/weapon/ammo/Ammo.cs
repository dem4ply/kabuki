using UnityEngine;
using System.Collections;


namespace weapon
{
	namespace ammo
	{
		[ CreateAssetMenu( menuName="weapon/ammo/base") ]
		public class Ammo : chibi_base.Chibi_object
		{
			public GameObject prefab_bullet;

			public override string path_of_the_default
			{
				get { return "object/weapon/ammo/default"; }
			}

			public virtual GameObject instanciate()
			{
				GameObject obj = helper.instantiate._( prefab_bullet );
				return obj;
			}
		}
	}
}