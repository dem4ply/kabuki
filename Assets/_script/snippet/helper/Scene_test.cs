using UnityEngine;
using System;
using NUnit.Framework;

namespace helper
{
	namespace tests
	{
		public class Scene_test
		{
			protected GameObject scene;

			public virtual string scene_dir
			{
				get { throw new NotImplementedException(); }
			}

			[SetUp]
			public virtual void Instanciate_scenary()
			{
				scene = Resources.Load( scene_dir ) as GameObject;
				scene = instantiate._( scene );
			}

			[TearDown]
			public virtual void clean_scenary()
			{
				MonoBehaviour.DestroyImmediate( scene );
				game_object.clean.scene();
			}
		}
	}
}
