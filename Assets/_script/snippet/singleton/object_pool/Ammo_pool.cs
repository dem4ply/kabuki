using UnityEngine;
using System.Collections.Generic;
using weapon.ammo;
using controller.motor;
using controller.controllers;

namespace singleton
{
	namespace object_pool
	{
		public class Ammo_pool : Singleton<Ammo_pool>
		{
			public string container_name
			{
				get {
					return "ammo_pool";
				}
			}

			public Transform container;

			protected Dictionary<Ammo, Stack<Bullet_controller_3d>> _dict;

			public Stack<Bullet_controller_3d> this[ Ammo key ] {
				get {
					Stack<Bullet_controller_3d> result;
					_dict.TryGetValue( key, out result );
					return result;
				}
			}

			protected virtual void OnEnable()
			{
				_dict = new Dictionary<Ammo, Stack<Bullet_controller_3d>>();
				if ( !container )
					container = helper.game_object.prepare.stuff_container(
						container_name ).transform;
			}

			public virtual Bullet_controller_3d pop( Ammo key )
			{
				Bullet_controller_3d result = null;
				if ( _dict.ContainsKey( key ) )
				{
					var stack = _dict[ key ];
					if ( stack.Count > 0 )
						result = stack.Pop();
				}
				if ( result == null )
				{
					// result = helper.instantiate.inactive._( key );
					result = instantiate( key );
				}
				else
					result.transform.parent = null;
				return result;
			}

			public virtual void push( Bullet_controller_3d value )
			{
				Ammo key = get_key( value );
				move_to_container( value );
				if ( _dict.ContainsKey( key ) )
					_dict[ key ].Push( value );
				else
				{
					Stack<Bullet_controller_3d> stack_tmp =
						new Stack< Bullet_controller_3d>();
					stack_tmp.Push( value );
					_dict.Add( key, stack_tmp );
				}
			}

			protected virtual void move_to_container( Bullet_controller_3d obj )
			{
				obj.transform.parent = container;
				obj.gameObject.SetActive( false );
			}

			public Bullet_controller_3d instantiate( Ammo key )
			{
				return key.instanciate_from_pool();
			}

			protected Ammo get_key( Bullet_controller_3d value )
			{
				var motor = value.GetComponent<Bullet_motor_3d>();
				return motor.ammo;
			}
		}
	}
}