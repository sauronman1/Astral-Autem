using UnityEngine;

namespace FG {
	public class PickUpSpawner : MonoBehaviour {
		[SerializeField] private GameObject[] _pickableObjects;
		[SerializeField] private float _timeBetweenPickupSpawn;
		private float _timer;

		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer > _timeBetweenPickupSpawn)
			{
				int randomObject = Random.Range(0, _pickableObjects.Length);
				Instantiate(_pickableObjects[randomObject],transform.position, transform.rotation);
				_timer = 0;
			}
		}
	}
}
