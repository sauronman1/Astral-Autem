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
			if (gameObject.GetComponent<Rigidbody2D>() != null)
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
			//TODO ändra alla så att de använder Rigidbody för att röra sig
			if (_body != null)
			{
				_body.velocity = _transform.up * 3;
			}
			else
				_transform.Translate(_transform.up*0.01f,Space.Self);
		}

		
	}
}
