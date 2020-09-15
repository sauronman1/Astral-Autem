using UnityEngine;

namespace FG {
	public class ProjectileMovement : MonoBehaviour
	{
		private Transform _transform;
		private Rigidbody2D _body;

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
			if (_body != null)
			{
				_body.velocity = _transform.up * 3;
			}
			else
				_transform.Translate(_transform.up*0.01f);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Shield") && gameObject.CompareTag("EnemyBullet"))
			{
				Destroy(gameObject);
			}
			else
			{
				if ((other.CompareTag("Enemy") && gameObject.CompareTag("PlayerBullet")))
				{
					if (other.gameObject.GetComponent<Seeker>().healthPoints < 1)
					{
						Destroy(other.gameObject);
					}
					else
					{
						other.gameObject.GetComponent<Seeker>().healthPoints -= 1;
					}
					Destroy(gameObject);
				}
			}
			if (other.CompareTag("Player") && gameObject.CompareTag("EnemyBullet"))
			{
				
			}
		}
	}
}
