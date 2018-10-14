using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEditor;
using snippet.objects;


namespace route
{
	namespace editor
	{
		[ CustomEditor( typeof( route.Route ) ) ]
		public class RouteInspector : Editor
		{
			protected float radius, nodes, x, y;
			protected int style_selected;

			public string[] STYLE_SHAPES = {
				"line", "circle", "sin(x) * y", "cos(x) * y", "tan(x) * y" };

			public override void OnInspectorGUI()
			{
				DrawDefaultInspector();
				Route component = ( Route )target;

				EditorGUILayout.BeginHorizontal();
				component.current_style = EditorGUILayout.Popup(
					"style", component.current_style, STYLE_SHAPES );
				component.style = Route.STYLE_SHAPES[ component.current_style ];
				bool reshape = GUILayout.Button( "reshape" );
				EditorGUILayout.EndHorizontal();

				inspect_style( component.current_style );

				if ( reshape )
					do_reshape( component.current_style );
			}

			public virtual void inspect_style( int style_selected )
			{
				switch ( style_selected )
				{
					case 0:
						break;
					case 1:
						inspect_circle();
						break;
					case 2:
					case 3:
					case 4:
						inspect_trigonometric();
						break;
				}
			}

			public virtual void do_reshape( int style_selected )
			{
				Route c = ( Route )target;
				switch ( c.current_style )
				{
					case 0:
						throw new System.NotImplementedException();
					case 1:
						c.draw_circle();
						break;
					case 2:
					case 3:
					case 4:
						throw new System.NotImplementedException();
				}
			}

			public virtual void inspect_circle()
			{
				Route c = ( Route )target;
				c.nodes = EditorGUILayout.IntField("nodes", c.nodes );
				c.radius = EditorGUILayout.FloatField( "radius", c.radius );
			}

			public virtual void inspect_trigonometric()
			{
				Route c = ( Route )target;
				c.nodes = EditorGUILayout.IntField("nodes", c.nodes );
				x = EditorGUILayout.FloatField( "x", 1 );
				y = EditorGUILayout.FloatField( "y", 1 );
			}
		}
	}
}
