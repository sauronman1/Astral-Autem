using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

namespace FG {
	public class Health : MonoBehaviour
	{
		[SerializeField] private GameObject            explosionParticle;
		[SerializeField] private GameObject            bulletCollisionParticle;
		[SerializeField] private bool                  isBoss;
		[SerializeField] private ShipController        ship;
		[SerializeField] private SliderBar             sliderBar;
		private                  GameObject            _canvas;
		private                  Transform             _transform;

		public float healthPoints;
		public float oneDamageToHealth             { get; private set; }
		public float currentHealthInMPropertyValue { get; private set; }

		private void OnEnable()
		{
			oneDamageToHealth = 1f / healthPoints;
			currentHealthInMPropertyValue = 1;
			Debug.Log(oneDamageToHealth);
			_transform = transform;
			if(isBoss)
				ship = GameObject.Find("Player").GetComponent<ShipController>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("EnemyBullet") && gameObject.CompareTag("Player") && GetComponent<ShipController>()._shieldActivated)
			{
				GameObject particleExplosion = Instantiate(bulletCollisionParticle);
				particleExplosion.transform.position = other.transform.position;
				Destroy(particleExplosion,1);
				Destroy(other.gameObject);
			}
			
			if ((other.CompareTag("PlayerBullet") && gameObject.CompareTag("Enemy")) || (other.CompareTag("EnemyBullet") && gameObject.CompareTag("Player") && !GetComponent<ShipController>()._shieldActivated))
			{
				//TODO change script name to Bullet
				healthPoints -= other.GetComponent<ProjectileMovement>().bulletDamage;
				GameObject particleExplosion = Instantiate(bulletCollisionParticle);
				particleExplosion.transform.position = other.transform.position;
				if(sliderBar)
					currentHealthInMPropertyValue = currentHealthInMPropertyValue - (oneDamageToHealth * other.GetComponent<ProjectileMovement>().bulletDamage);
				Destroy(particleExplosion,1);
				Destroy(other.gameObject);
			}
			else if (other.CompareTag("Missile") && gameObject.CompareTag("Enemy"))
			{
				healthPoints -= other.GetComponent<HomingMissile>().missileDamage;
				GameObject particleExplosion = Instantiate(explosionParticle);
				particleExplosion.transform.position = other.transform.position;
				if(sliderBar)
					currentHealthInMPropertyValue = currentHealthInMPropertyValue - (oneDamageToHealth * other.GetComponent<HomingMissile>().missileDamage);
				currentHealthInMPropertyValue = 1f - oneDamageToHealth;
				Destroy(particleExplosion,1);
				Destroy(other.gameObject);
			}
			
			if (healthPoints < 1)
			{
				if (isBoss && ship != null)
				{
					ship.victoryScreen.SetActive(true);
				}
				GameObject particleExplosion = Instantiate(explosionParticle, _transform.position, _transform.rotation);
				Destroy(particleExplosion,1);
				Destroy(gameObject);
			}
		}
	}
}
