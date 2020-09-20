using UnityEngine;

namespace FG {
	public class PlayerInput : MonoBehaviour
	{
		private ShipController _ship;
		private WeaponManager _weaponManager;

		private void Start()
		{
			_ship = GetComponent<ShipController>();
			_weaponManager = GetComponent<WeaponManager>();
		}

		private void Update()
		{
			_ship.sideMovementInput = Input.GetAxis("Horizontal");
			_ship.verticalMovementInput = Input.GetAxis("Vertical");
			_weaponManager.fired = Input.GetButtonDown("Fire1");
			_ship.shieldInput = Input.GetAxis("Shield");
			_ship.missileFired = Input.GetButtonDown("FireMissile");
			_ship.tutorialButtonInput = Input.GetAxis("Tutorial");
		}
	}
}
