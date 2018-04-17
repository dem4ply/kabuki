using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace damage
{
	namespace motor
	{
		public class HP_motor : chibi_base.Chibi_behaviour
		{
			public int total_of_points = 1;
			public int current_points = 1;

			public LayerMask damage_mask;
			public GameObject receives_damage;
			public controller.motor.Motor_2d motor;

			public virtual bool is_dead
			{
				get {
					return current_points <= 0;
				}
			}

			public virtual void take_damage( Damage damage )
			{
				current_points -= damage.amount;
				if ( is_dead )
					send_died();
			}

			protected virtual void OnTriggerEnter2D( Collider2D other )
			{
				var damage_layer_in_bit = 1 << other.gameObject.layer;

				if ( ( damage_mask.value & damage_layer_in_bit ) > 0 )
				{
					Debug.Log( "es un trigger de dano" );
					Damage damage = other.GetComponent<Damage>();
					if ( damage == null )
					{
						Debug.LogError( "no tiene el componente de dano" );
						return;
					}
					take_damage( damage );
					damage.taken();
				}
			}

			protected virtual void send_died()
			{
				motor.died();
			}

			protected override void _init_cache()
			{
				base._init_cache();
				if ( motor == null )
				{
					motor = GetComponent< controller.motor.Motor_2d >();
					if ( motor == null )
						Debug.LogError( "no se encontro el motor" );
				}
			}
		}
	}
}
