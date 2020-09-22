using System;
using UnityEngine;

namespace FG {
	public class PlayerInput : MonoBehaviour
	{
		[NonSerialized] public bool isPaused = true;
		private ShipController _ship;
		private WeaponManager _weaponManager;

		private void Start()
		{
			_ship = GetComponent<ShipController>();
			_weaponManager = GetComponent<WeaponManager>();
		}

		private void Update()
		{
			if (!isPaused)
			{
				_ship.sideMovementInput = Input.GetAxis("Horizontal");
				_ship.verticalMovementInput = Input.GetAxis("Vertical");
				_weaponManager.fired = Input.GetButtonDown("Fire1");
				_ship.shieldInput = Input.GetAxis("Shield");
				_ship.missileFired = Input.GetButtonDown("FireMissile");
				_ship.tutorialButtonInput = Input.GetAxis("Tutorial");
			}
		}

		public void StartGame()
		{
			isPaused = false;
		}
	}
}
