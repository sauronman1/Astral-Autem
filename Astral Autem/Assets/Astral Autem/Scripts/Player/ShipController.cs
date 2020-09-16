﻿using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace FG {
	public class ShipController : MonoBehaviour
	{
		[NonSerialized] public float sideMovementInput;
		[NonSerialized] public float verticalMovementInput;
		[NonSerialized] public bool missileFired = false;
		[NonSerialized] public float shieldInput;
		public float playerSpeed;
		public float shieldCooldown;
		public float shieldDuration;

		[SerializeField] private GameObject _missile;
		[SerializeField][Range(5, 0)]private float _maxAllowedHeightWithinScreen;
		private Vector2 _movement;
		private Vector2 _screenBounds;
		private Vector2 _screenLockedPosition;
		private Transform _transform;
		private Rigidbody2D _body;
		private float _playerWidth;
		private float _playerHeight;
		private float _inputAmount;
		public float shieldTimeSinceActivated;
		public bool shieldActivated;

		private void Start()
		{
			_transform = transform;
			_body = GetComponent<Rigidbody2D>();
			_screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
			_playerWidth = _transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
			_playerHeight = _transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
		}

		private void Update()
		{
			Move();
			Shield();
			FireMissile();
		}

		private void Move()
		{
			_movement = (_transform.right * sideMovementInput  + _transform.up * verticalMovementInput).normalized;
			_inputAmount = Mathf.Clamp01(Mathf.Abs(sideMovementInput) + Mathf.Abs(verticalMovementInput));
			_body.velocity = _movement * (playerSpeed * _inputAmount);
			_screenLockedPosition = _transform.position;
			_screenLockedPosition.x = Mathf.Clamp(_transform.position.x, _screenBounds.x * -1 + _playerWidth,
				_screenBounds.x - _playerWidth);
			_screenLockedPosition.y = Mathf.Clamp(_transform.position.y, _screenBounds.y * -1 + _playerHeight,
				_screenBounds.y - _playerHeight-_maxAllowedHeightWithinScreen);
			_transform.position = _screenLockedPosition;
		}

		private void Shield()
		{
			if (shieldInput > 0 && shieldTimeSinceActivated > shieldCooldown)
				shieldActivated = true;
			
			if (shieldTimeSinceActivated > shieldCooldown && !shieldActivated) 
				shieldTimeSinceActivated = shieldCooldown;
			
			shieldTimeSinceActivated += Time.deltaTime;
			if (shieldTimeSinceActivated > shieldCooldown)
			{
				if (shieldActivated)
				{
					gameObject.transform.GetChild(0).gameObject.SetActive(true);
					if (shieldTimeSinceActivated > (shieldDuration + shieldCooldown))
					{
						gameObject.transform.GetChild(0).gameObject.SetActive(false);
						shieldActivated = false;
						shieldTimeSinceActivated = 0;
					}
				}

			}
		}

		private void FireMissile()
		{
			if (missileFired)
			{
				Instantiate(_missile, _transform.position, _transform.rotation);
				missileFired = true;
			}
		}
	}
}
