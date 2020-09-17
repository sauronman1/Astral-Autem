using UnityEngine;

namespace FG {
	public class ProjectileMovement : MonoBehaviour
	{
		private Transform _transform;
		private Rigidbody2D _body;
		private float _timer;

		public int bulletDamage;
		public int bulletLife;

		private void Start()
		{
			_transform = transform;
			_body = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			Move();
		}

		private void Move()
		{
			_body.velocity = _transform.up * 3;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("BulletBoundary"))
			{
				if (_transform.parent != null)
					Destroy(_transform.parent.gameObject);
				else
					Destroy(gameObject);
			}
		}
	}
}
