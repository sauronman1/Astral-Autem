using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace FG {
	public class ShipController : MonoBehaviour
	{
		[NonSerialized] public float sideMovementInput;
		[NonSerialized] public float verticalMovementInput;
		[NonSerialized] public bool missileFired;
		[NonSerialized] public float shieldInput;
		[NonSerialized] public float tutorialButtonInput;
		public GameObject victoryScreen;
		public GameObject shieldIndicator;
		public GameObject missileIndicator;

		[SerializeField] private GameObject _missile;
		[SerializeField][Range(5, 0)]private float _maxAllowedHeightWithinScreen; 
		[SerializeField] private float _missileCooldown;
		[SerializeField] private GameObject _tutorialScreen;
		[SerializeField] private float _playerSpeed;
		[SerializeField] private float _shieldCooldown;
		[SerializeField] private float _shieldDuration;
		private bool _showTutorial;
		private Vector2 _movement;
		private Vector2 _screenBounds;
		private Vector2 _screenLockedPosition;
		private Transform _transform;
		private Rigidbody2D _body;
		private float _playerWidth;
		private float _playerHeight;
		private float _inputAmount;
		private float _shieldTimeSinceActivated;
		private float _timeSinceMissileFired;
		private bool _shieldActivated;

		private void Start()
		{
			_transform = transform;
			_body = GetComponent<Rigidbody2D>();
			_screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
			_playerWidth = _transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
			_playerHeight = _transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
			victoryScreen.SetActive(false);
			_timeSinceMissileFired = _missileCooldown + 1;
			_shieldTimeSinceActivated = _shieldCooldown;
		}

		private void Update()
		{
			Move();
			Shield();
			FireMissile();
			ShowTutorial();
		}

		private void Move()
		{
			_movement = (_transform.right * sideMovementInput  + _transform.up * verticalMovementInput).normalized;
			_inputAmount = Mathf.Clamp01(Mathf.Abs(sideMovementInput) + Mathf.Abs(verticalMovementInput));
			_body.velocity = _movement * (_playerSpeed * _inputAmount);
			_screenLockedPosition = _transform.position;
			_screenLockedPosition.x = Mathf.Clamp(_transform.position.x, _screenBounds.x * -1 + _playerWidth,
				_screenBounds.x - _playerWidth);
			_screenLockedPosition.y = Mathf.Clamp(_transform.position.y, _screenBounds.y * -1 + _playerHeight,
				_screenBounds.y - _playerHeight-_maxAllowedHeightWithinScreen);
			_transform.position = _screenLockedPosition;
		}

		private void Shield()
		{
			if (shieldInput > 0 && _shieldTimeSinceActivated > _shieldCooldown)
				_shieldActivated = true;

			if (_shieldTimeSinceActivated > _shieldCooldown && !_shieldActivated)
			{
				_shieldTimeSinceActivated = _shieldCooldown;
				shieldIndicator.SetActive(true);
			}

			_shieldTimeSinceActivated += Time.deltaTime;
			if (_shieldTimeSinceActivated > _shieldCooldown)
			{
				if (_shieldActivated)
				{
					shieldIndicator.SetActive(false);
					gameObject.transform.GetChild(0).gameObject.SetActive(true);
					if (_shieldTimeSinceActivated > (_shieldDuration + _shieldCooldown))
					{
						gameObject.transform.GetChild(0).gameObject.SetActive(false);
						_shieldActivated = false;
						_shieldTimeSinceActivated = 0;
					}
				}

			}
		}

		private void FireMissile()
		{
			_timeSinceMissileFired += Time.deltaTime;
			if (_timeSinceMissileFired > _missileCooldown)
			{
				missileIndicator.SetActive(true);
			}
			if (missileFired && _timeSinceMissileFired > _missileCooldown)
			{
				_timeSinceMissileFired = 0;
				Instantiate(_missile, _transform.position, _transform.rotation);
				missileIndicator.SetActive(false);
				missileFired = true;
			}
		}

		private void ShowTutorial()
		{
			if (tutorialButtonInput > 0)
			{
				_showTutorial = !_showTutorial;
				_tutorialScreen.SetActive(_showTutorial);
			}
		}
	}
}
