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
			GameObject bullet = Instantiate(Resources.Load("ProjectilePrefab",typeof(GameObject)), transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class Killer : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject killer = Instantiate(Resources.Load("ScatterShot",typeof(GameObject)), transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class SeekerWeapon : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject enemyProjectile = Instantiate(Resources.Load("Seeker Bullet", typeof(GameObject)), transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class InquisitorWeapon : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject enemyProjectile = Instantiate(Resources.Load("Inquisitor Bullet", typeof(GameObject)), transform.position, transform.rotation) as GameObject;
		}
	}
	
	public class PrincipalityWeapon : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{
			GameObject enemyProjectile = Instantiate(Resources.Load("Multi Strike", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
		}
	}
}
