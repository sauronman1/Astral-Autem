using System.Collections;
using UnityEngine;

namespace FG {
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private bool _randomizePosition = false;
		private float _timeUntilWaveStart;
		private float _waitTimeBetweenSpawns;
		private GameObject _enemy;
		private float _enemyCount;
		private Transform _transform;
		private Vector2 _screenBounds;

		public SpawnerData data;

		private void Start()
		{
			_transform = transform;
			StartCoroutine("StartWave");
			_timeUntilWaveStart = data._timeUntilWaveStart;
			_waitTimeBetweenSpawns = data._waitTimeBetweenSpawns;
			_enemy = data._enemy;
			_enemyCount = data._enemyCount;
			_screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		}

		
		
		private IEnumerator StartWave(){
			yield return new WaitForSeconds(_timeUntilWaveStart);
			for (int i = 0; i < _enemyCount; i++)
			{
				if (_randomizePosition)
				{
					Vector2 randomPosition = _transform.position;
					randomPosition.x = Random.Range(_screenBounds.x * -1 + 3, _screenBounds.x - 3);
					Instantiate(_enemy, randomPosition, _transform.rotation);
					yield return new WaitForSeconds(_waitTimeBetweenSpawns);
				}
				else
				{
					Instantiate(_enemy, _transform.position, _transform.rotation);
					yield return new WaitForSeconds(_waitTimeBetweenSpawns);
				}
			}
		}
	}
}
