using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace damage
{
	public class Damage : chibi_base.Chibi_behaviour {
		public damage.Damage damage;
		public behavior.Beavior behavior;
		[HideInInspector] public float amount = 1;

		protected List<motor.HP_motor> _taken_by;

		public List<motor.HP_motor> taken_by
		{
			get {
				return _taken_by;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if ( damage != null )
			{
				amount = damage.amount;
			}
			_taken_by = new List<motor.HP_motor>();
		}

		public virtual void taken( motor.HP_motor hp_motor )
		{
			if ( !taken_by.Contains( hp_motor ) )
				taken_by.Add( hp_motor );
			Debug.Log( string.Format( "dano tomado por {0}", hp_motor.name ) );
			if ( behavior != null )
				behavior.taken_damange( this );
			else
				Debug.Log(
					string.Format(
						"el {0} damage no tiene un behavior", gameObject ) );
		}
	}
}