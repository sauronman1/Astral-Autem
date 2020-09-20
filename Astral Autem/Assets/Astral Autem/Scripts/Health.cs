using UnityEngine;
using UnityEngine.UI;

namespace FG {
	public class Health : MonoBehaviour
	{
		[SerializeField] private int _healthPoints;
		[SerializeField] private GameObject _explosionParticle;
		[SerializeField] private GameObject _bulletCollisionParticle;
		[SerializeField] private bool _isBoss;
		[SerializeField] private ShipController _ship;
		[SerializeField] private Text _healthPointsIndicator;
		private GameObject _canvas;
		private Transform _transform;

		private void Start()
		{
			_transform = transform;
			if(_healthPointsIndicator)
				_healthPointsIndicator.text = "HP: " + _healthPoints;
			if(_isBoss)
				_ship = GameObject.Find("Player").GetComponent<ShipController>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("PlayerBullet") && gameObject.CompareTag("Enemy"))
			{
				//TODO change script name to Bullet
				_healthPoints -= other.GetComponent<ProjectileMovement>().bulletDamage;
				GameObject particleExplosion = Instantiate(_bulletCollisionParticle);
				particleExplosion.transform.position = other.transform.position;
				Destroy(particleExplosion,1);
				Destroy(other.gameObject);
			}
			if (other.CompareTag("EnemyBullet") && gameObject.CompareTag("Player"))
			{
				_healthPoints -= other.GetComponent<ProjectileMovement>().bulletDamage;
				GameObject particleExplosion = Instantiate(_bulletCollisionParticle);
				particleExplosion.transform.position = other.transform.position;
				_healthPointsIndicator.text = "HP: " + _healthPoints;
				Destroy(particleExplosion,1);
				Destroy(other.gameObject);
			}
			else if (other.CompareTag("Missile") && gameObject.CompareTag("Enemy"))
			{
				_healthPoints -= other.GetComponent<HomingMissile>().missileDamage;
				GameObject particleExplosion = Instantiate(_explosionParticle);
				particleExplosion.transform.position = other.transform.position;
				Destroy(particleExplosion,1);
				Destroy(other.gameObject);
			}
			
			if (_healthPoints < 1)
			{
				if (_isBoss && _ship != null)
				{
					_ship.victoryScreen.SetActive(true);
				}
				GameObject particleExplosion = Instantiate(_explosionParticle, _transform.position, _transform.rotation);
				Destroy(particleExplosion,1);
				Destroy(gameObject);
			}
		}
	}
}
