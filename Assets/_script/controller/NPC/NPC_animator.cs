using UnityEngine;
using System.Collections;
using System;

namespace controller {
	namespace animator {
		public class NPC_animator : animator.Animator_base{
			protected Vector2 _move_vector = Vector2.zero;
			protected bool _is_moving = false;
			protected bool _is_running = false;

			public const string VERTICAL = "vertical";
			public const string HORIZONTAL = "horizontal";
			public const string IS_MOVING = "is_moving";
			public const string IS_RUNNING = "is_running";

			public virtual Vector2 direction_vector {
				set {
					_move_vector = value;
					animator.SetFloat( HORIZONTAL, _move_vector.x );
					animator.SetFloat( VERTICAL, _move_vector.y );
				}
			}

			public virtual bool is_moving {
				get {
					return _is_moving;
				}
				set {
					_is_moving = value;
					animator.SetBool( IS_MOVING, _is_moving );
				}
			}

			public virtual bool is_running {
				get {
					return _is_running;
				}
				set {
					_is_running = value;
					animator.SetBool( IS_RUNNING, _is_running );
				}
			}
		}
	}
}