using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using controller.ai;
using controller.controllers;


namespace ai
{
	namespace behavior
	{

		public class Test_ai_walk_when_intanciate
		{
			GameObject player, floor;

			[SetUp]
			public void Instanciate_scenary()
			{
				player =
					( GameObject )Resources.Load(
						"_prefab/tests/ai simple_walk" );
				floor =
					( GameObject )Resources.Load(
						"_prefab/tests/floor_1" );
				player = helper.instantiate._( player );
				floor = helper.instantiate._( floor );
			}

			[TearDown]
			public void clean_scenary()
			{
				MonoBehaviour.DestroyImmediate( player );
				MonoBehaviour.DestroyImmediate( floor );
			}

			[UnityTest]
			public IEnumerator when_desire_pos_is_left_should_move_to_left()
			{
				Ai_walk ai = player.transform.GetComponent<Ai_walk>();
				Vector3 initial_position = player.transform.position;
				ai.desire_direction = Vector2.left;
				yield return new WaitForSeconds( 1 );
				Assert.Greater( initial_position.x, player.transform.position.x );
			}

			[UnityTest]
			public IEnumerator when_desire_pos_is_righ_should_move_to_right()
			{
				Ai_walk ai = player.transform.GetComponent<Ai_walk>();
				Vector3 initial_position = player.transform.position;
				ai.desire_direction = Vector2.right;
				yield return new WaitForSeconds( 1 );
				Assert.Greater( player.transform.position.x, initial_position.x );
			}
		}
	}
}
