using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace route
{
	public class Route : chibi_base.Chibi_behaviour, IList<Segment>
	{

		public List<Transform> points;
		public float width = 0.5f;
		public GameObject asdf;

		public int Count
		{
			get {
				return points.Count - 1;
			}
		}

		public bool IsReadOnly
		{
			get {
				throw new System.NotImplementedException();
			}
		}

		public Segment this[ int index ]
		{
			get {
				return new Segment( points[ index ], points[ index + 1 ], width, index );
			}

			set {
				throw new System.NotImplementedException();
			}
		}

		public Segment give_the_next_segment( Segment segment )
		{
			try
			{
				return this[ segment.index + 1 ];
			}
			catch ( System.ArgumentOutOfRangeException ) {
				if ( segment.index > Count )
					return this[ Count ];
				return this[ segment.index ];
			}
		}

		public Transform find_near_point( Vector3 position )
		{
			float min_distance = ( points[ 0 ].position - position ).magnitude;
			int min_index = 0;
			for ( int i = 1; i < points.Count; ++i )
			{
				float current_distant = ( points[ i ].position - position ).magnitude;
				if ( current_distant < min_distance )
				{
					min_distance = current_distant;
					min_index = i;
				}
			}
			return points[ min_index ];
		}

		public Segment find_nearest_segment( Vector3 position )
		{
			IEnumerator< Segment > segments = get_segments().GetEnumerator();
			segments.MoveNext();
			float min_distance = segments.Current.distance_of( position );
			Segment nearest_segment = segments.Current;

			while ( segments.MoveNext() )
			{
				float current_distance = segments.Current.distance_of( position );
				if ( current_distance < min_distance )
				{
					min_distance = current_distance;
					nearest_segment = segments.Current;
				}
			}

			return nearest_segment;
		}

		protected void OnDrawGizmos()
		{
			for ( int i = 0; i < Count - 1; ++i )
			{
				foreach ( Segment segment in get_segments() )
				{
					segment.draw_gizmo();
				}
			}
		}

		public IEnumerable<Segment> get_segments()
		{
			for ( int i = 0; i < Count; ++i )
			{
				yield return new Segment(
					points[ i ], points[ i + 1 ], width, i );
			}
		}

		public int IndexOf( Segment item )
		{
			throw new System.NotImplementedException();
		}

		public void Insert( int index, Segment item )
		{
			throw new System.NotImplementedException();
		}

		public void RemoveAt( int index )
		{
			throw new System.NotImplementedException();
		}

		public void Add( Segment item )
		{
			throw new System.NotImplementedException();
		}

		public void Clear()
		{
			throw new System.NotImplementedException();
		}

		public bool Contains( Segment item )
		{
			throw new System.NotImplementedException();
		}

		public void CopyTo( Segment[] array, int arrayIndex )
		{
			throw new System.NotImplementedException();
		}

		public bool Remove( Segment item )
		{
			throw new System.NotImplementedException();
		}

		public IEnumerator<Segment> GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
	}
}
