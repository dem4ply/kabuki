using UnityEngine;

namespace damage
{
	namespace motor
	{
		public class HP_motor : chibi_base.Chibi_behaviour
		{
			public stat.Hp_stat stat;
			[HideInInspector] public float total_of_points = 1;
			[HideInInspector] public float current_points = 1;

			public LayerMask damage_mask;
			public GameObject receives_damage;
			public controller.motor.Motor_base motor;

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
				{
					Debug.Log( string.Format( "murio: {0}", name ) );
					send_died();
				}
			}

			protected virtual void OnTriggerEnter2D( Collider2D other )
			{
				if ( helper.layer_mask.game_object_is_in_mask(
					other.gameObject, damage_mask ) )
				{
					Damage damage = other.GetComponent<Damage>();
					proccess_damage( damage );
				}
			}

			protected virtual void OnTriggerEnter( Collider other )
			{
				log_trigger( other );
				if ( helper.layer_mask.game_object_is_in_mask(
					other.gameObject, damage_mask ) )
				{
					Damage damage = other.GetComponent<Damage>();
					proccess_damage( damage );
				}
			}

			protected virtual void proccess_damage( Damage damage )
			{
				if ( damage == null )
				{
					Debug.LogError( "no tiene el componente de dano" );
					return;
				}
				take_damage( damage );
				damage.taken( this );
			}

			protected virtual void log_trigger( Collider other )
			{
				string msg = string.Format(
					"el {0} toco un trigger de danno {1}",
					this.name, other.name );

				Debug.Log( msg );
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
					motor = GetComponent< controller.motor.Motor_base >();
					if ( motor == null )
						Debug.LogError( "no se encontro el motor" );
					if ( damage_mask.value == 0 )
						damage_mask = helper.consts.layers.receives_damage;
					if ( receives_damage == null )
						receives_damage =
							transform.Find( "receives_damage" ).gameObject;
					if ( stat != null )
					{
						total_of_points = stat.total;
						current_points = stat.current;
					}
				}
			}
		}
	}
}
