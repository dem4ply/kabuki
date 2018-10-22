using UnityEngine;
using System.Collections.Generic;


namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace state
				{
					[CreateAssetMenu( menuName = "controller/ai/state/base" )]
					public abstract class State : chibi_base.Chibi_object
					{
						public List<behavior.Behavior> behaviors;

						public void update( Controller_3d controller )
						{
							do_actions( controller );
						}

						public virtual void do_actions( Controller_3d controller )
						{
							foreach ( behavior.Behavior behavior in behaviors )
								behavior.act( controller );
						}
					}
				}
			}
		}
	}
}
