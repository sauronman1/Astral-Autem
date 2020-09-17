using UnityEngine;

namespace FG {
	public class Inquisitor : MonoBehaviour
	{
		[SerializeField]private float movementSpeed;
		[SerializeField]private float frequency;
		[SerializeField]private float magnitude;
		private Vector3 pos;
		private Transform _transform;
		private float _timeSinceCreation;
		private float _timeSinceLastShot;
		private WeaponManager _weaponManager;

		public float shooterCooldown;
		
		private void Start()
		{
			_transform = transform;
			pos = _transform.position;
			_weaponManager = GetComponent<WeaponManager>();
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
			pos += _transform.up * Time.deltaTime * movementSpeed;
			_timeSinceCreation += Time.deltaTime;
			_transform.position = pos + _transform.right * Mathf.Sin(_timeSinceCreation * frequency) * magnitude;
		}
		
		private void Shoot()
		{
			_weaponManager.fired = true;
		}
	}
}
