using UnityEngine;

namespace FG {
	public class HomingMissile : MonoBehaviour
	{
		[SerializeField] private float _rotationSmoothnes;
		private GameObject[] _targets;
		private Transform _nearestTarget;
		private Transform _transform;
		private Rigidbody2D _body;

		public float speed;
		public int missileDamage;
		
		private void Start()
		{
			_targets = GameObject.FindGameObjectsWithTag("Enemy");
			_transform = transform;
			_body = GetComponent<Rigidbody2D>();
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 10,  1<<LayerMask.NameToLayer("Enemy"));
			foreach (var hitCollider in hitColliders)
			{
				Debug.Log("AddDamage");
			}
		}

		private void Update()
		{
			FlyTowardsTarget();
		}

		private void FindNearestTarget()
		{
			if (_nearestTarget == null)
			{
				Collider2D[] hitColliders =
					Physics2D.OverlapCircleAll(transform.position, 10, 1 << LayerMask.NameToLayer("Enemy"));
				if (hitColliders.Length > 0)
				{
					_nearestTarget = hitColliders[0].transform;
					for (int i = 1; i < _targets.Length; i++)
					{
						foreach (Collider2D hitCollider in hitColliders)
						{
							if (Vector2.Distance(_nearestTarget.position, gameObject.transform.position) >
							    Vector2.Distance(hitCollider.transform.position, gameObject.transform.position))
							{
								_nearestTarget = hitCollider.transform;
							}
						}

					}
				}

			}
		}

		private void FlyTowardsTarget()
		{
			FindNearestTarget();
			if (_nearestTarget != null)
			{
				Vector2 difference = _nearestTarget.transform.position - transform.position;
				float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
				_transform.rotation = transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ - 90), Time.time * _rotationSmoothnes);
			}
			_body.velocity = _transform.up * speed;
		}
	}
}
