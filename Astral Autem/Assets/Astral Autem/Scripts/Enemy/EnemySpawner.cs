using System.Collections;
using UnityEngine;

namespace FG {
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private bool _randomizePosition = false;
		[SerializeField] private SpawnerData _data;
		private int _timeUntilWaveStart;
		private float _waitTimeBetweenSpawns;
		private GameObject _enemy;
		private float _enemyCount;
		private Transform _transform;
		private Vector2 _screenBounds;
		
		private void Start()
		{
			_transform = transform;
			_timeUntilWaveStart = _data._timeUntilWaveStart;
			_waitTimeBetweenSpawns = _data._waitTimeBetweenSpawns;
			_enemy = _data._enemy;
			_enemyCount = _data._enemyCount;
			_screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
			StartCoroutine(StartWave(_timeUntilWaveStart));
		}

		
		
		private IEnumerator StartWave(float delay)
		{
			yield return new WaitForSeconds(delay);
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
