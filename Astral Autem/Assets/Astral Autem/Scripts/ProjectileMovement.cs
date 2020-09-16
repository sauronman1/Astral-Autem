using UnityEngine;

namespace FG {
	public class ProjectileMovement : MonoBehaviour
	{
		private Transform _transform;
		private Rigidbody2D _body;
		
		public int bulletDamage;

		private void Start()
		{
			_transform = transform;
			_body = GetComponent<Rigidbody2D>();
			if (_transform.parent != null)
				Destroy(_transform.parent.gameObject, 3);
			else
				Destroy(gameObject,3);
		}

		private void Update()
		{
			Move();
		}

		private void Move()
		{
			_body.velocity = _transform.up * 3;
		}
	}
}
