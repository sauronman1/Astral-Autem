using UnityEngine;

namespace FG {
	public class ProjectileMovement : MonoBehaviour
	{
		private Rigidbody2D _body;

		private void Start()
		{
			_body = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			//TODO Switch rigidbody to be on enemies instead of projectiles
			_body.velocity = transform.up * 3f;
		}
	}
}
