using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace damage
{
	public class Damage : chibi_base.Chibi_behaviour {
		public damage.Damage damage;
		[HideInInspector] public float amount = 1;

		protected override void Awake()
		{
			if ( damage != null )
			{
				amount = damage.amount;
			}
		}

		public virtual void taken()
		{
			Debug.Log( "dano tomado" );
		}
    }
}