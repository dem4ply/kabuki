using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {


	protected Transform _transform;
	public Camera eye;
	public GameObject qwer;

	public float tile_width = 0.315f;
	public float tile_height = 0.315f;

	public int col = 23;
	public int row = 23;

	// Use this for initialization
	void Start() {
		_init_cache();
		BoxCollider2D c = this.GetComponent<BoxCollider2D>();
		Bounds b = c.bounds;
		Vector2 s = c.size;
		Debug.Log( s );
		tile_width = s.x / row;
		tile_height = s.y / col;
	}

	protected void FixedUpdate() {
		if ( Input.GetMouseButton( 0 ) ) {
			Ray ray = eye.ScreenPointToRay( Input.mousePosition );
			Debug.DrawRay( ray.origin, ( ray.direction ) * 100, Color.magenta );
			RaycastHit2D hit = Physics2D.Raycast( ray.origin, ( ray.direction - _transform.position ), Mathf.Infinity );
			if ( hit.collider != null ) {
				Debug.Log( hit.collider );
				test_post( hit.point );
			}
		}
	}

	protected void test_post( Vector2 pos ) {
		BoxCollider2D c = this.GetComponent<BoxCollider2D>();
		Bounds b = c.bounds;
		Vector2 min = b.min;
		Vector2 local = pos - min;
		local.x = Mathf.Floor( local.x / tile_width );
		local.y = Mathf.Floor( local.y / tile_height );
		if ( local.x >= row )
			local.x -= 1;
		else if ( local.x < 0 )
			local.x = 0;
		if ( local.y >= col )
			local.y -= 1;
		else if ( local.y < 0 )
			local.y = 0;
		Debug.Log( "local 2: " + local.ToString() );
		Vector2 tmp = new Vector2( min.x + local.x * tile_width + tile_width * 0.5f, min.y + local.y * tile_height + tile_height * 0.5f );
		Debug.Log( "tmp: " + tmp.ToString() );
		helper.instantiate._( qwer, tmp );
	}

	protected void _init_cache() {
		_transform = this.GetComponent<Transform>();
	}
}
