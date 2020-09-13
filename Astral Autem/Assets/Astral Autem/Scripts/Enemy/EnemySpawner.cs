using System.Collections;
using UnityEngine;

namespace FG {
	public class EnemySpawner : MonoBehaviour
	{
		private float _timeUntilWaveStart;
		private float _waitTimeBetweenSpawns;
		private GameObject _enemy;
		private float _enemyCount;
		private Transform _transform;

		public SpawnerData data;

		private void Start()
		{
			_transform = transform;
			StartCoroutine("StartWave");
			_timeUntilWaveStart = data._timeUntilWaveStart;
			_waitTimeBetweenSpawns = data._waitTimeBetweenSpawns;
			_enemy = data._enemy;
			_enemyCount = data._enemyCount;
		}

		
		
		private IEnumerator StartWave(){
			yield return new WaitForSeconds(_timeUntilWaveStart);
			for (int i = 0; i < _enemyCount; i++)
			{
				Instantiate(_enemy, _transform.position, _transform.rotation);
				yield return new WaitForSeconds(_waitTimeBetweenSpawns);
			}
	
		}
	}
}
