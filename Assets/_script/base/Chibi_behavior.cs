using UnityEngine;
using System.Collections;

namespace chibi_base {
	public class Chibi_behaviour : MonoBehaviour {

		protected bool _is_drawing_gizmo;

		protected bool _is_instanciate;

		protected virtual void Start() {
			_init_cache();
		}

		protected virtual void _init_cache() {}

		public void gizmo_awake() {
			_is_drawing_gizmo = true;
			Start();
			_is_drawing_gizmo = false;
		}

		public void extert_init_cache() {
			_init_cache();
		}
	}
}
