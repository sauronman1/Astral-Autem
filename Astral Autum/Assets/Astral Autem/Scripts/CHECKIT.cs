using UnityEngine;

namespace FG {
	public class CHECKIT : MonoBehaviour {
		
		[Range( 1, 128 )]  [SerializeField] private int        count;
		[Range( 0f, 90f )] [SerializeField] private float      spreadAngleDeg;
		[SerializeField]                    private GameObject bullet;

		private void Start()
		{
			Shoot();
		}
		
		void Shoot() {
			float angSpread = spreadAngleDeg * Mathf.Deg2Rad;
			float angBetweenBullets = count == 1 ? 0 : angSpread / ( count - 1f );
			float angOffset = count == 1 ? 0 : angSpread / 2f;
			for( int i = 0; i < count; i++ ) {
				float angle = angBetweenBullets * i - angOffset;

				Vector2 pos = new Vector2( Mathf.Cos( angle ), Mathf.Sin( angle ) );
				Vector2 bulletTrajectory = pos - (Vector2)transform.position;
				Quaternion q = Quaternion.FromToRotation(transform.right, pos);

				GameObject bulletPrefab = Instantiate(bullet,transform.position, bullet.transform.rotation * q);
			}
		}

		private void OnDrawGizmos()
		{
			float angSpread = spreadAngleDeg * Mathf.Deg2Rad;

			// angle between each bullet
			float angBetweenBullets = count == 1 ? 0 : angSpread / ( count - 1f );

			// offset to center bullets
			float angOffset = count == 1 ? 0 : angSpread / 2;
			for( int i = 0; i < count; i++ ) {
				// angle for this bullet
				float angle = angBetweenBullets * (i) - angOffset;

				// angle to direction
				Vector2 pos = new Vector2( Mathf.Cos( angle - 4.75f), Mathf.Sin( angle - 4.75f) );
				// draw
				Gizmos.DrawLine( transform.position, pos+(Vector2)transform.position);
				Gizmos.DrawSphere((Vector2)transform.position+ pos, 0.04f );
			}
		}
	}
}
