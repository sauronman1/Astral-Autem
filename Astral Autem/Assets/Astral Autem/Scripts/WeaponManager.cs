﻿using System;
using UnityEngine;

namespace FG {
	public enum Weapon
	{
		Bullet,
		Killer
	}
	
	public class WeaponManager : MonoBehaviour
	{
		[NonSerialized] public bool fired;
		public Weapon weapon;

		private IWeapon iWeapon;

		private void HandleWeapon()
		{
			Component c = gameObject.GetComponent<IWeapon>() as Component;

			if (c != null)
			{
				Destroy(c);
			}

			switch (weapon)
			{
				case Weapon.Bullet:
					iWeapon = gameObject.AddComponent<Bullet>();
					break;
				case Weapon.Killer:
					iWeapon = gameObject.AddComponent<Killer>();
					break;
				default:
					iWeapon = gameObject.AddComponent<Bullet>();
					break;
			}
		}
		
		public void Fire()
		{
			iWeapon.Shoot();
		}

		private void Start()
		{
				HandleWeapon();
		}

		private void Update()
		{
			if (fired)
			{
				Fire();
			}

			if (Input.GetKeyDown(KeyCode.C))
			{
				HandleWeapon();
			}
		}
	}
}
