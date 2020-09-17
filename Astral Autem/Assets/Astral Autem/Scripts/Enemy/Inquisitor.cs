using UnityEngine;

namespace FG {
	public class Inquisitor : MonoBehaviour
	{
		[SerializeField]private float movementSpeed;
		[SerializeField]private float frequency;
		[SerializeField]private float magnitude;
		private Vector3 pos;
		private Transform _transform;
		
		private void Start()
		{
			_transform = transform;
			pos = _transform.position;
		}

		private void Update()
		{
			MoveDown();
		}

		private void MoveDown()
		{
			pos += -_transform.up * Time.deltaTime * movementSpeed;
			_transform.position = pos + _transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
		}
	}
}
