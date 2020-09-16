using UnityEngine;

namespace FG {
	public class HomingMissile : MonoBehaviour
	{
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
		}

		private void Update()
		{
			FlyTowardsTarget();
		}

		private Transform FindNearestTarget()
		{
			//TODO använd Physics2D overlapCircle för att ta in alla neaarby targets som är inuti circlen, 
			//Ta en ny lista av targets om target är förstörd innan missilen når de, och låt den gå rakt om det inte finns några targets.
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
			_body.velocity = _transform.up * speed;
		}
	}
}
