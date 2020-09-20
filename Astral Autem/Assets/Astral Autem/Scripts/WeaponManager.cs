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
	
	public class WeaponManager : MonoBehaviour
	{
		[NonSerialized] public bool fired;
		public Weapon weapon;

		private IWeapon iWeapon;
		private int _bulletQue = 0;

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
					iWeapon = gameObject.AddComponent<Bullet>();
					break;
				case Weapon.Killer:
					iWeapon = gameObject.AddComponent<Killer>();
					break;
				case Weapon.SeekerBullet:
					iWeapon = gameObject.AddComponent<SeekerWeapon>();
					break;
				case Weapon.InquisitorBullet:
					iWeapon = gameObject.AddComponent<InquisitorWeapon>();
					break;
				case Weapon.MultiStrike:
					iWeapon = gameObject.AddComponent<PrincipalityWeapon>();
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
						HandleWeapon(Weapon.Bullet);
						Destroy(other.gameObject);
						break;
					case "ScatterShot":
						HandleWeapon(Weapon.Killer);
						Destroy(other.gameObject);
						break;
				}
			}
		}
	}
}
