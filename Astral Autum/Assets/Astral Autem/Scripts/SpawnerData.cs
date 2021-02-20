using UnityEngine;

namespace FG {
	[CreateAssetMenu(fileName = "SpawnerData", menuName = "ScriptableObject/EnemySpawner")]
	public class SpawnerData : ScriptableObject {
		public int _timeUntilWaveStart;
		public float _waitTimeBetweenSpawns;
		public GameObject _enemy;
		public float _enemyCount;
	}
}
