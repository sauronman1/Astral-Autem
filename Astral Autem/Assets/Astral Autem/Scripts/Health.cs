using UnityEngine;

namespace FG {
	public class Health : MonoBehaviour
	{
		public int healthPoints;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("PlayerBullet") && gameObject.CompareTag("Enemy"))
			{
				//TODO change script name to Bullet
				healthPoints -= other.GetComponent<ProjectileMovement>().bulletDamage;
				Destroy(other.gameObject);
			}
			if (other.CompareTag("EnemyBullet") && gameObject.CompareTag("Player"))
			{
				healthPoints -= other.GetComponent<ProjectileMovement>().bulletDamage;
				Destroy(other.gameObject);
			}
			else if (other.CompareTag("Missile"))
			{
				healthPoints -= other.GetComponent<HomingMissile>().missileDamage;
				Destroy(other.gameObject);
			}
			
			if (healthPoints < 1)
			{
				Destroy(gameObject);
			}
		}
	}
}
