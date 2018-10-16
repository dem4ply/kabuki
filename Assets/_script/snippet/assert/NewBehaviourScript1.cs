using UnityEngine;
using NUnit.Framework;
using System.Collections;


namespace tests_tool
{
	namespace assert
	{
		public class Vector
		{
			public static void equal( Vector3 v1, Vector3 v2, float delta )
			{
				Assert.AreEqual( v1.x, v2.x, delta );
			}
		}
	}
}