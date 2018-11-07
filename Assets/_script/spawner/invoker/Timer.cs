using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	namespace invoker
	{
		public class Timer : Invoker
		{
			public float delta_time = 1f;

			protected float _sigma_time = 0f;

			protected void Update()
			{
				_sigma_time += Time.deltaTime;
				if ( _sigma_time >= delta_time )
				{
					target.spawn();
					_sigma_time = 0;
				}
			}
		}
	}
}