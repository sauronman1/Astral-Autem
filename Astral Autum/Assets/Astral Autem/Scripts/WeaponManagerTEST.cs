using System;
using TMPro;
using UnityEngine;

namespace FG {
	
	
	
	public class WeaponManagerTEST : MonoBehaviour
	{
		[NonSerialized] public bool fired;
		public Weapon weapon;
		public GameObject[] bullets;

		private IWeapon iWeapon;
		private Transform _transform;
		private int _bulletQue = 0;
		private ShipController _ship;

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
					for (int i = 0; i < bullets.Length; i++)
					{
				//		bullets[i] = iWeapon.Shoot();
					}
					break;
				case Weapon.Killer:
					iWeapon = gameObject.AddComponent<Killer>();
					for (int i = 0; i < bullets.Length; i++)
					{
				//		GameObject bullet = iWeapon.Shoot();
				//		bullet.SetActive(false);
				//		bullets[i] = bullet;
					}
					break;
				case Weapon.SeekerBullet:
					iWeapon = gameObject.AddComponent<SeekerWeapon>();
					for (int i = 0; i < bullets.Length; i++)
					{
						// GameObject bullet = iWeapon.Shoot();
						// bullet.SetActive(false);
						// bullets[i] = bullet;
					}
					break;
				case Weapon.InquisitorBullet:
					iWeapon = gameObject.AddComponent<InquisitorWeapon>();
					for (int i = 0; i < bullets.Length; i++)
					{
						// GameObject bullet = iWeapon.Shoot();
						// bullet.SetActive(false);
						// bullets[i] = bullet;;
					}
					break;
				default:
					iWeapon = gameObject.AddComponent<Bullet>();
					for (int i = 0; i < bullets.Length; i++)
					{
						// GameObject bullet = iWeapon.Shoot();
						// bullet.SetActive(false);
						// bullets[i] = bullet;
					}
					break;
			}
		}
		
		public void Fire()
		{
			if (bullets[_bulletQue].transform.childCount > 0)
			{
				for(int i = 0; i < bullets[_bulletQue].transform.childCount; i++)
				{
					bullets[_bulletQue].transform.GetChild(i).transform.position = _transform.position;
				}
			}
			bullets[_bulletQue].transform.position = _transform.position;
			bullets[_bulletQue].SetActive(true);
			_bulletQue += 1;
			if (_bulletQue > bullets.Length-1)
				_bulletQue = 0;
		}

		private void Start()
		{
			HandleWeapon(weapon);
			_transform = transform;
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
