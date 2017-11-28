using UnityEngine;
using System.Collections;
using controller.animator;
using System;

namespace controller
{
	namespace motor
	{
		public class Unitychan_motor : NPC_motor
		{
			public GameObject model;

			public override void update_motion()
			{
				base.update_motion();
				update_model();
			}


			public virtual void update_model()
			{
				Vector3 model_local_scale = model.transform.localScale;
				if ( _rigidbody.velocity.x > 0 )
					model.transform.localScale = new Vector3(
						1, model_local_scale.y, model_local_scale.z );
				else if ( _rigidbody.velocity.x < 0 )
					model.transform.localScale = new Vector3(
						-1, model_local_scale.y, model_local_scale.z );
			}

			protected override void _init_cache()
			{
				base._init_cache();
				if ( model == null )
					model = _transform.Find( "model" ).gameObject;
			}
		}
	}
}