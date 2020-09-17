using System.Collections;
using UnityEngine;

namespace FG {
	public class Seeker : MonoBehaviour
	{
		private Transform _transform;
		private Vector2 _endPos;
		private float _movementTimer;
		private float _timeSinceLastShot;
		private float _durationOfJourney = 20;
		private WeaponManager _weaponManager;
		private GameObject _player;

		public float shooterCooldown;

		private void Start()
		{
			_transform = transform;
			_endPos = new Vector2(_transform.position.x, _transform.position.y-5);
			_weaponManager = GetComponent<WeaponManager>();
			_player = GameObject.Find("Player");
		}

		private void Update()
		{
			Move();
			_timeSinceLastShot += Time.deltaTime;
			if (_timeSinceLastShot > shooterCooldown)
			{
				Shoot();
				_timeSinceLastShot = 0;
			}

		}

		private void Move()
		{
			_movementTimer += Time.deltaTime / _durationOfJourney;
			_transform.position = Vector3.Lerp(transform.position, _endPos, _movementTimer);
			
			if (Vector2.Distance(_transform.position, _endPos) < 1)
			{
				Vector2 difference = _player.transform.position - transform.position;
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
