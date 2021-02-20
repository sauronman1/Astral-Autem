using UnityEngine;

namespace FG {
	public class Principality : MonoBehaviour {
		[SerializeField] private float _distance;
		[SerializeField] private float _durationOfJourney;
		[SerializeField] private float shooterCooldown;
		[SerializeField]private float _frequency;
		[SerializeField]private float _magnitude;
		private Transform _transform;
		private Vector2 _endPos;
		private Vector3 pos;
		private WeaponsSystem _weaponsSystem;
		private float _movementTimer;
		private float _timeSinceLastShot;
		private float _timeSinceCreation;

		private void Start()
		{
			_transform = transform;
			_endPos = new Vector2(_transform.position.x, _transform.position.y-_distance);
			_weaponsSystem = GetComponent<WeaponsSystem>();
		}

		private void Update()
		{
			MoveDown();
			MoveSideways();			
			Shoot();
		}

		private void MoveDown()
		{
			_movementTimer += Time.deltaTime / _durationOfJourney;
			_transform.position = Vector3.Lerp(transform.position, _endPos, _movementTimer);
		}

		private void MoveSideways()
		{
			if (_movementTimer > 0.03f)
			{
				_timeSinceCreation += Time.deltaTime;
				_transform.position = new Vector3(0.0f, _transform.position.y, 0) + _transform.right * Mathf.Sin(_timeSinceCreation * _frequency) * _magnitude;
			}
		}

		private void Shoot()
		{
			_timeSinceLastShot += Time.deltaTime;
			if (_timeSinceLastShot > shooterCooldown)
			{
				_weaponsSystem.fired = true;
				_timeSinceLastShot = 0;
			}
		
		}
	}
}
