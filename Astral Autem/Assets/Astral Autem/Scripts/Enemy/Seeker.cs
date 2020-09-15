using System.Collections;
using UnityEngine;

namespace FG {
	public class Seeker : MonoBehaviour
	{
		private Transform _transform;
		private Rigidbody2D _body;
		private Vector2 _endPos;
		private float _movementTimer;
		private float _shooterCooldown;
		private float _durationOfJourney = 20;
		private WeaponManager _weaponManager;
		

		public int healthPoints;

		private void Start()
		{
			_transform = transform;
			_body = GetComponent<Rigidbody2D>();
			_endPos = new Vector2(_transform.position.x, _transform.position.y-5);
			_weaponManager = GetComponent<WeaponManager>();
		}

		private void Update()
		{
			Move();
			_shooterCooldown += Time.deltaTime;
			if (_shooterCooldown > 1)
			{
				Shoot();
				_shooterCooldown = 0;
			}

		}

		private void Move()
		{
			_movementTimer += Time.deltaTime / _durationOfJourney;
			_transform.position = Vector3.Lerp(transform.position, _endPos, _movementTimer);
			
			if (Vector2.Distance(_transform.position, _endPos) < 1)
			{
				Vector2 difference = GameObject.Find("Player").transform.position - transform.position;
				float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
				_transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
			}
		}

		private void Shoot()
		{
			_weaponManager.fired = true;
		}
	}
}
