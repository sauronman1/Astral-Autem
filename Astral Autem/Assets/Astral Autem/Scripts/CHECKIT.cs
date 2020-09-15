using UnityEngine;

namespace FG {
	public class CHECKIT : MonoBehaviour {
		
		[Range( 1, 128 )] public int count;
		[Range( 0f, 90f )] public float spreadAngleDeg;

		private void Start()
		{
			OnDrawGizmos();
		}
		
		void OnDrawGizmos() {
			// convert spread to radians
			float angSpread = spreadAngleDeg * Mathf.Deg2Rad;

			// angle between each bullet
			float angBetweenBullets = count == 1 ? 0 : angSpread / ( count - 1f );

			// offset to center bullets
			float angOffset = count == 1 ? 0 : angSpread / 2f;
			for( int i = 0; i < count; i++ ) {
				// angle for this bullet
				float angle = angBetweenBullets * i - angOffset;

				// angle to direction
				Vector2 pos = new Vector2( Mathf.Cos( angle ), Mathf.Sin( angle ) );
				// draw
				Gizmos.DrawLine( transform.position, pos );
				Gizmos.DrawSphere( pos, 0.04f );
			}
		}

	
	}
}
