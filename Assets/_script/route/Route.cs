using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace route
{
	public class Route : chibi_base.Chibi_behaviour, IList<GameObject>
	{

		public List<GameObject> points;
		public float width = 0.5f;

		public GameObject find_near_point( Vector3 position )
		{
			float min_distance = ( this[ 0 ].transform.position - position ).magnitude;
			int min_index = 0;
			for ( int i = 1; i < Count; ++i )
			{
				float current_distant = ( this[ i ].transform.position - position ).magnitude;
				if ( current_distant < min_distance )
				{
					min_distance = current_distant;
					min_index = i;
				}
			}
			return this[ min_index ];
		}

		protected void OnDrawGizmos()
		{
			for ( int i = 0; i < Count - 1; ++i )
			{
				Vector3 position = this[ i ].transform.position;
				Vector3 direction = this[ i + 1 ].transform.position - position;
				Vector3 d2 = Quaternion.Euler( 0, 0, 90 ) * direction;
				Vector3 d3 = Quaternion.Euler( 0, 0, -90 ) * direction;
				d2 = position + ( d2.normalized * width );
				d3 = position + ( d3.normalized * width );
				helper.draw.arrow.gizmo( position, direction, Color.green );
				helper.draw.arrow.gizmo( d2, direction, Color.red );
				helper.draw.arrow.gizmo( d3, direction, Color.red );
			}
		}

		public GameObject this[ int index ]
		{
			get {
				return ( ( IList<GameObject> )points )[ index ];
			}

			set {
				( ( IList<GameObject> )points )[ index ] = value;
			}
		}

		public int Count
		{
			get {
				return ( ( IList<GameObject> )points ).Count;
			}
		}

		public bool IsReadOnly
		{
			get {
				return ( ( IList<GameObject> )points ).IsReadOnly;
			}
		}

		public void Add( GameObject item )
		{
			( ( IList<GameObject> )points ).Add( item );
		}

		public void Clear()
		{
			( ( IList<GameObject> )points ).Clear();
		}

		public bool Contains( GameObject item )
		{
			return ( ( IList<GameObject> )points ).Contains( item );
		}

		public void CopyTo( GameObject[] array, int arrayIndex )
		{
			( ( IList<GameObject> )points ).CopyTo( array, arrayIndex );
		}

		public IEnumerator<GameObject> GetEnumerator()
		{
			return ( ( IList<GameObject> )points ).GetEnumerator();
		}

		public int IndexOf( GameObject item )
		{
			return ( ( IList<GameObject> )points ).IndexOf( item );
		}

		public void Insert( int index, GameObject item )
		{
			( ( IList<GameObject> )points ).Insert( index, item );
		}

		public bool Remove( GameObject item )
		{
			return ( ( IList<GameObject> )points ).Remove( item );
		}

		public void RemoveAt( int index )
		{
			( ( IList<GameObject> )points ).RemoveAt( index );
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ( ( IList<GameObject> )points ).GetEnumerator();
		}
	}
}
