using System;
using TMPro;
using UnityEngine;

namespace FG {
	public enum Weapon
	{
		Bullet,
		Killer,
		SeekerBullet,
		InquisitorBullet,
		MultiStrike
	}
	
	public class WeaponsSystem : MonoBehaviour
	{
		[NonSerialized] public bool    fired;
		public                Weapon  weapon;
		
		private                IWeapon _iWeapon;
		private                int     _bulletQue = 0;

		private void HandleWeapon(Weapon chosenWeapon)
		{
			Component c = gameObject.GetComponent<IWeapon>() as Component;

			if (c != null)
			{
				Destroy(c);
			}

			switch (chosenWeapon)
			{
				case Weapon.Bullet:
					_iWeapon = gameObject.AddComponent<Bullet>();
					break;
				case Weapon.Killer:
					_iWeapon = gameObject.AddComponent<Killer>();
					break;
				case Weapon.SeekerBullet:
					_iWeapon = gameObject.AddComponent<SeekerWeapon>();
					break;
				case Weapon.InquisitorBullet:
					_iWeapon = gameObject.AddComponent<InquisitorWeapon>();
					break;
				case Weapon.MultiStrike:
					_iWeapon = gameObject.AddComponent<PrincipalityWeapon>();
					break;
				default:
					_iWeapon = gameObject.AddComponent<Bullet>();
					break;
			}
		}
		
		public void Fire()
		{
			_iWeapon.Shoot();
		}

		private void Start()
		{
			HandleWeapon(weapon);
		}

		private void Update()
		{
			if (fired)
			{
				Fire();
				fired = false;
			}

			if (Input.GetKeyDown(KeyCode.C))
			{
				HandleWeapon(weapon);
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (gameObject.CompareTag("Player"))
			{
				switch (other.tag)
				{
					case "Blaster":
						weapon = Weapon.Bullet;
						HandleWeapon(weapon);
						Destroy(other.gameObject);
						break;
					case "ScatterShot":
						weapon = Weapon.Killer;
						HandleWeapon(weapon);
						Destroy(other.gameObject);
						break;
				}
			}
		}
	}
}
