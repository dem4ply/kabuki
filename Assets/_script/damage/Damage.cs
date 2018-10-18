using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace damage
{

	public enum Type
	{
		blunt,
		slash,
		piercing,
	}

	public class Damage : chibi_base.Chibi_behaviour {
		public Type type;
		public int amount = 1;
		public List< Damage > side_effect;

		public virtual void taken()
		{
			Debug.Log( "dano tomado" );
		}
    }
}