using UnityEngine;

namespace FG {
	public class ProjectileMovement : MonoBehaviour
	{
		[SerializeField] private float _speed;
		private Transform _transform;
		private Rigidbody2D _body;
		private float _timer;

		public int bulletDamage;

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
			_body.velocity = _transform.up * _speed;
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
