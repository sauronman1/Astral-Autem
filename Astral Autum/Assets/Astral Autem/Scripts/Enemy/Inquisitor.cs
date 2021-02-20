using UnityEngine;

namespace FG {
	public class Inquisitor : MonoBehaviour
	{
		[SerializeField]private float _movementSpeed;
		[SerializeField]private float _frequency;
		[SerializeField]private float _magnitude;
		private float _lifetime = 13;
		private Vector3 pos;
		private Transform _transform;
		private float _timeSinceCreation;
		private float _timeSinceLastShot;
		private WeaponsSystem _weaponsSystem;

		public float shooterCooldown;
		
		private void Start()
		{
			_transform = transform;
			pos = _transform.position;
			_weaponsSystem = GetComponent<WeaponsSystem>();
			Destroy(gameObject, _lifetime/_movementSpeed);
		}

		private void Update()
		{
			MoveDown();
			_timeSinceLastShot += Time.deltaTime;
			if (_timeSinceLastShot > shooterCooldown)
			{
				Shoot();
				_timeSinceLastShot = 0;
			}
		}

		private void MoveDown()
		{
			pos += _transform.up * Time.deltaTime * _movementSpeed;
			_timeSinceCreation += Time.deltaTime;
			_transform.position = pos + _transform.right * Mathf.Sin(_timeSinceCreation * _frequency) * _magnitude;
		}
		
		private void Shoot()
		{
			_weaponsSystem.fired = true;
		}
	}
}
