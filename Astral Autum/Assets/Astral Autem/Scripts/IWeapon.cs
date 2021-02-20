using UnityEngine;

namespace FG {
	public interface IWeapon
	{
		void Shoot();
	}

	public class Bullet : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject bullet = Instantiate(WeaponsManager.WeaponsList[(int)GetComponent<WeaponsSystem>().weapon], transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class Killer : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject killer = Instantiate(WeaponsManager.WeaponsList[(int)GetComponent<WeaponsSystem>().weapon], transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class SeekerWeapon : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject enemyProjectile = Instantiate(WeaponsManager.WeaponsList[(int)GetComponent<WeaponsSystem>().weapon], transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class InquisitorWeapon : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject enemyProjectile = Instantiate(WeaponsManager.WeaponsList[(int)GetComponent<WeaponsSystem>().weapon], transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class PrincipalityWeapon : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject enemyProjectile = Instantiate(WeaponsManager.WeaponsList[(int)GetComponent<WeaponsSystem>().weapon], transform.position, Quaternion.identity) as GameObject;
		}
	}
}
