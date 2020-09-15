using UnityEngine;

namespace FG {
	public class HomingMissile : MonoBehaviour
	{
		private GameObject[] _targets;
		private Transform _nearestTarget;
		private Transform _transform;

		private void Start()
		{
			_targets = GameObject.FindGameObjectsWithTag("Enemy");
			_transform = transform;
		}

		private void Update()
		{
			FlyTowardsTarget();
		}

		private Transform FindNearestTarget()
		{
			_nearestTarget = _targets[0].transform;
			for (int i = 1; i < _targets.Length; i++)
			{
				if (Vector2.Distance(_nearestTarget.position, gameObject.transform.position) >
				    Vector2.Distance(_targets[i].transform.position, gameObject.transform.position))
				{
					_nearestTarget = _targets[i].transform;
				}
			}

			return _nearestTarget;
		}

		private void FlyTowardsTarget()
		{
			Vector2 difference = FindNearestTarget().transform.position - transform.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			_transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
		}
	}
}
