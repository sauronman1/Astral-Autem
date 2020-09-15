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
	
	public class EnemyProjectile : MonoBehaviour, IWeapon
	{
		public void Shoot()
		{

			GameObject enemyProjectile = Instantiate(Resources.Load("Enemy Bullet", typeof(GameObject)), transform.position, transform.rotation) as GameObject;
			
		}
	}
}
